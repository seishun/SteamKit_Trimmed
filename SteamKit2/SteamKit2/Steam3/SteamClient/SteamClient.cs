﻿/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamKit2
{
    /// <summary>
    /// Represents a single client that connects to the Steam3 network.
    /// This class is also responsible for handling the registration of client message handlers and callbacks.
    /// </summary>
    public sealed partial class SteamClient : CMClient
    {
        Dictionary<string, ClientMsgHandler> handlers;

        object callbackLock = new object();
        Queue<CallbackMsg> callbackQueue;


        /// <summary>
        /// Initializes a new instance of the <see cref="SteamClient"/> class.
        /// </summary>
        public SteamClient()
        {
            this.handlers = new Dictionary<string, ClientMsgHandler>( StringComparer.OrdinalIgnoreCase );
            this.callbackQueue = new Queue<CallbackMsg>();

            // add this library's handlers
            this.AddHandler( new SteamUser() );
            this.AddHandler( new SteamFriends() );
        }

        /// <summary>
        /// Adds a new handler to the internal list of message handlers.
        /// </summary>
        /// <param name="handler">The handler to add.</param>
        /// <exception cref="InvalidOperationException">
        /// A handler with that name is already registered.
        /// </exception>
        public void AddHandler( ClientMsgHandler handler )
        {
            if ( handlers.ContainsKey( handler.Name ) )
                throw new InvalidOperationException( string.Format( "A handler with name \"{0}\" is already registered.", handler.Name ) );

            handlers[ handler.Name ] = handler;
            handler.Setup( this );
        }
        /// <summary>
        /// Removes a registered handler by name.
        /// </summary>
        /// <param name="handler">The handler name to remove.</param>
        public void RemoveHandler( string handler )
        {
            if ( !handlers.ContainsKey( handler ) )
                return;

            handlers.Remove( handler );
        }
        public void RemoveHandler( ClientMsgHandler handler )
        {
            this.RemoveHandler( handler.Name );
        }

        /// <summary>
        /// Returns a registered handler by name.
        /// </summary>
        /// <typeparam name="T">The type of the handler to cast to. Must derive from ClientMsgHandler</typeparam>
        /// <param name="name">The name of the handler to get.</param>
        /// <returns>A registered handler on success, or null if the handler could not be found.</returns>
        public T GetHandler<T>( string name ) where T : ClientMsgHandler
        {
            if ( handlers.ContainsKey( name ) )
                return ( T )handlers[ name ];

            return null;
        }


        /// <summary>
        /// Gets the next callback object in the queue. This function does not dequeue the callback, you must call FreeLastCallback after processing it.
        /// </summary>
        /// <returns>The next callback in the queue, or null if no callback is waiting.</returns>
        public CallbackMsg GetCallback()
        {
            CallbackMsg msg = null;

            lock ( callbackLock )
            {
                if ( callbackQueue.Count > 0 )
                    msg = callbackQueue.Peek();
            }

            return msg;
        }
        /// <summary>
        /// Frees the last callback in the queue.
        /// </summary>
        public void FreeLastCallback()
        {
            lock ( callbackLock )
            {
                if ( callbackQueue.Count == 0 )
                    return;

                callbackQueue.Dequeue();
            }
        }
        /// <summary>
        /// Posts a callback to the queue. This is normally used by client message handlers.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void PostCallback( CallbackMsg msg )
        {
            if ( msg == null )
                return;

            lock ( callbackLock )
            {
                callbackQueue.Enqueue( msg );
            }
        }



        protected override void OnClientMsgReceived( ClientMsgEventArgs e )
        {
            base.OnClientMsgReceived( e );

            if ( e.EMsg == EMsg.ChannelEncryptResult )
                HandleEncryptResult( e );

            // pass along the clientmsg to all registered handlers
            foreach ( var kvp in handlers )
            {
                kvp.Value.HandleMsg( e );
            }
        }


        // we're interested in handling the encryption result callback to see if we've properly connected or not
        void HandleEncryptResult( ClientMsgEventArgs e )
        {
            // if the EResult is OK, we've finished the crypto handshake and can send commands (such as LogOn)
            ClientMsg<MsgChannelEncryptResult, MsgHdr> encResult = null;

            try
            {
                encResult = new ClientMsg<MsgChannelEncryptResult, MsgHdr>( e.Data );
            }
            catch ( Exception ex )
            {
                DebugLog.WriteLine( "SteamClient", "HandleEncryptResult encountered an exception while reading client msg.\n{0}", ex.ToString() );
                return;

                // todo: should we post a callback here?
            }

            PostCallback( new ConnectCallback( encResult.Msg ) );
        }

    }
}
