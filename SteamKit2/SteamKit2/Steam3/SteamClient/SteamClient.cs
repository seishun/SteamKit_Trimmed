﻿/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SteamKit2
{
    /// <summary>
    /// Represents a single client that connects to the Steam3 network.
    /// This class is also responsible for handling the registration of client message handlers and callbacks.
    /// </summary>
    public sealed partial class SteamClient : CMClient
    {
        Dictionary<Type, ClientMsgHandler> handlers;

        long currentJobId = 0;

#if STATIC_CALLBACKS
        static object callbackLock = new object();
        static Queue<CallbackMsg> callbackQueue;
#else
        object callbackLock = new object();
        Queue<CallbackMsg> callbackQueue;
#endif


#if STATIC_CALLBACKS
        static SteamClient()
        {
            callbackQueue = new Queue<CallbackMsg>();
        }
#endif


        /// <summary>
        /// Initializes a new instance of the <see cref="SteamClient"/> class with a specific connection type.
        /// </summary>
        /// <param name="type">The connection type to use.</param>
        public SteamClient( CMClient.ConnectionType type = ConnectionType.Tcp )
            : base( type )
        {
#if !STATIC_CALLBACKS
            callbackQueue = new Queue<CallbackMsg>();
#endif
            this.handlers = new Dictionary<Type, ClientMsgHandler>();

            // add this library's handlers
            this.AddHandler( new SteamUser() );
            this.AddHandler( new SteamFriends() );
            this.AddHandler( new SteamApps() );
            this.AddHandler( new SteamGameCoordinator() );
            this.AddHandler( new SteamGameServer() );
            this.AddHandler( new SteamUserStats() );
        }


        #region Handlers
        /// <summary>
        /// Adds a new handler to the internal list of message handlers.
        /// </summary>
        /// <param name="handler">The handler to add.</param>
        /// <exception cref="InvalidOperationException">
        /// A handler with that name is already registered.
        /// </exception>
        public void AddHandler( ClientMsgHandler handler )
        {
            if ( handlers.ContainsKey( handler.GetType() ) )
                throw new InvalidOperationException( string.Format( "A handler of type \"{0}\" is already registered.", handler.GetType() ) );

            handlers[ handler.GetType() ] = handler;
            handler.Setup( this );
        }

        /// <summary>
        /// Removes a registered handler by name.
        /// </summary>
        /// <param name="handler">The handler name to remove.</param>
        public void RemoveHandler( Type handler )
        {
            if ( !handlers.ContainsKey( handler ) )
                return;

            handlers.Remove( handler );
        }
        /// <summary>
        /// Removes a registered handler.
        /// </summary>
        /// <param name="handler">The handler to remove.</param>
        public void RemoveHandler( ClientMsgHandler handler )
        {
            this.RemoveHandler( handler.GetType() );
        }

        /// <summary>
        /// Returns a registered handler.
        /// </summary>
        /// <typeparam name="T">The type of the handler to cast to. Must derive from ClientMsgHandler.</typeparam>
        /// <returns>
        /// A registered handler on success, or null if the handler could not be found.
        /// </returns>
        public T GetHandler<T>()
            where T : ClientMsgHandler
        {
            Type type = typeof( T );

            if ( handlers.ContainsKey( type ) )
                return handlers[ type ] as T;

            return null;
        }
        #endregion


        #region Callbacks
        /// <summary>
        /// Gets the next callback object in the queue.
        /// This function does not dequeue the callback, you must call FreeLastCallback after processing it.
        /// </summary>
        /// <returns>The next callback in the queue, or null if no callback is waiting.</returns>
#if STATIC_CALLBACKS
        public static CallbackMsg GetCallback()
#else
        public CallbackMsg GetCallback()
#endif
        {
            return GetCallback( false );
        }
        /// <summary>
        /// Gets the next callback object in the queue, and optionally frees it.
        /// </summary>
        /// <param name="freeLast">if set to <c>true</c> this function also frees the last callback if one existed.</param>
        /// <returns>The next callback in the queue, or null if no callback is waiting.</returns>
#if STATIC_CALLBACKS
        public static CallbackMsg GetCallback( bool freeLast )
#else
        public CallbackMsg GetCallback( bool freeLast )
#endif
        {
            lock ( callbackLock )
            {
                if ( callbackQueue.Count > 0 )
                    return ( freeLast ? callbackQueue.Dequeue() : callbackQueue.Peek() );
            }

            return null;
        }

        /// <summary>
        /// Blocks the calling thread until a callback object is posted to the queue.
        /// This function does not dequeue the callback, you must call FreeLastCallback after processing it.
        /// </summary>
        /// <returns>The callback object from the queue.</returns>
#if STATIC_CALLBACKS
        public static CallbackMsg WaitForCallback()
#else
        public CallbackMsg WaitForCallback()
#endif
        {
            return WaitForCallback( false );
        }
        /// <summary>
        /// Blocks the calling thread until a callback object is posted to the queue, or null after the timeout has elapsed.
        /// This function does not dequeue the callback, you must call FreeLastCallback after processing it.
        /// </summary>
        /// <param name="timeout">The length of time to block.</param>
        /// <returns>A callback object from the queue if a callback has been posted, or null if the timeout has elapsed.</returns>
#if STATIC_CALLBACKS
        public static CallbackMsg WaitForCallback( TimeSpan timeout )
#else
        public CallbackMsg WaitForCallback( TimeSpan timeout )
#endif
        {
            lock ( callbackLock )
            {
                if ( callbackQueue.Count == 0 )
                {
                    if ( !Monitor.Wait( callbackLock, timeout ) )
                        return null;
                }

                return callbackQueue.Peek();
            }
        }
        /// <summary>
        /// Blocks the calling thread until a callback object is posted to the queue, and optionally frees it.
        /// </summary>
        /// <param name="freeLast">if set to <c>true</c> this function also frees the last callback.</param>
        /// <returns>The callback object from the queue.</returns>
#if STATIC_CALLBACKS
        public static CallbackMsg WaitForCallback( bool freeLast )
#else
        public CallbackMsg WaitForCallback( bool freeLast )
#endif
        {
            lock ( callbackLock )
            {
                if ( callbackQueue.Count == 0 )
                    Monitor.Wait( callbackLock );

                return ( freeLast ? callbackQueue.Dequeue() : callbackQueue.Peek() );
            }
        }
        /// <summary>
        /// Blocks the calling thread until a callback object is posted to the queue, and optionally frees it.
        /// </summary>
        /// <param name="freeLast">if set to <c>true</c> this function also frees the last callback.</param>
        /// <param name="timeout">The length of time to block.</param>
        /// <returns>A callback object from the queue if a callback has been posted, or null if the timeout has elapsed.</returns>
#if STATIC_CALLBACKS
        public static CallbackMsg WaitForCallback( bool freeLast, TimeSpan timeout )
#else
        public CallbackMsg WaitForCallback( bool freeLast, TimeSpan timeout )
#endif
        {
            lock ( callbackLock )
            {
                if ( callbackQueue.Count == 0 )
                {
                    if ( !Monitor.Wait( callbackLock, timeout ) )
                        return null;
                }

                return ( freeLast ? callbackQueue.Dequeue() : callbackQueue.Peek() );
            }
        }

        /// <summary>
        /// Frees the last callback in the queue.
        /// </summary>
#if STATIC_CALLBACKS
        public static void FreeLastCallback()
#else
        public void FreeLastCallback()
#endif
        {
            lock ( callbackLock )
            {
                if ( callbackQueue.Count == 0 )
                    return;

                callbackQueue.Dequeue();
            }
        }

        /// <summary>
        /// Posts a callback to the queue. This is normally used directly by client message handlers.
        /// </summary>
        /// <param name="msg">The message.</param>
#if STATIC_CALLBACKS
        public static void PostCallback( CallbackMsg msg )
#else
        public void PostCallback( CallbackMsg msg )
#endif
        {
            if ( msg == null )
                return;

            lock ( callbackLock )
            {
                callbackQueue.Enqueue( msg );
                Monitor.Pulse( callbackLock );
            }
        }
        #endregion


        public long GetNextJobID()
        {
            return Interlocked.Increment( ref currentJobId );
        }


        /// <summary>
        /// Raises the <see cref="E:ClientMsgReceived"/> event.
        /// </summary>
        /// <param name="e">The <see cref="SteamKit2.ClientMsgEventArgs"/> instance containing the event data.</param>
        protected override void OnClientMsgReceived( ClientMsgEventArgs e )
        {
            if ( e.EMsg == EMsg.ChannelEncryptResult )
                HandleEncryptResult( e );

            // pass along the clientmsg to all registered handlers
            foreach ( var kvp in handlers )
            {
                kvp.Value.HandleMsg( e );
            }
        }
        /// <summary>
        /// Called when the client is physically disconnected from Steam3.
        /// </summary>
        protected override void OnClientDisconnected()
        {
#if STATIC_CALLBACKS
            SteamClient.PostCallback( new DisconnectCallback( this ) );
#else
            this.PostCallback( new DisconnectCallback() );
#endif
        }


        // we're interested in handling the encryption result net message to see if we've properly connected or not
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

#if STATIC_CALLBACKS
                SteamClient.PostCallback( new ConnectCallback( this, EResult.Fail ) );
#else
                PostCallback( new ConnectCallback( EResult.Fail ) );
#endif
                return;
            }

#if STATIC_CALLBACKS
            SteamClient.PostCallback( new ConnectCallback( this, encResult.Msg ) );
#else
            PostCallback( new ConnectCallback( encResult.Msg ) );
#endif
        }

    }
}
