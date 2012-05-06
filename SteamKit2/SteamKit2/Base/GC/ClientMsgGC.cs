﻿/*
 * This file is subject to the terms and conditions defined in
 * file 'license.txt', which is part of this source code package.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ProtoBuf;
using SteamKit2.GC.Internal;
using MsgGCHdrProtoBuf = SteamKit2.Internal.MsgGCHdrProtoBuf;
using MsgGCHdr = SteamKit2.Internal.MsgGCHdr;

namespace SteamKit2.GC
{
    /// <summary>
    /// Represents a protobuf backed game coordinator message.
    /// </summary>
    /// <typeparam name="BodyType">The body type of this message.</typeparam>
    public sealed class ClientGCMsgProtobuf<BodyType> : GCMsgBase<MsgGCHdrProtoBuf>
        where BodyType : IExtensible, new()
    {
        /// <summary>
        /// Gets a value indicating whether this gc message is protobuf backed.
        /// Client messages of this type are always protobuf backed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is protobuf backed; otherwise, <c>false</c>.
        /// </value>
        public override bool IsProto { get { return true; } }
        /// <summary>
        /// Gets the network message type of this gc message.
        /// </summary>
        /// <value>
        /// The network message type.
        /// </value>
        public override uint MsgType { get { return Header.Msg; } }

        /// <summary>
        /// Gets or sets the session id for this gc message.
        /// </summary>
        /// <value>
        /// The session id.
        /// </value>
        public override int SessionID
        {
            get { return ProtoHeader.client_session_id; }
            set { ProtoHeader.client_session_id = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="SteamID"/> for this gc message.
        /// </summary>
        /// <value>
        /// The <see cref="SteamID"/>.
        /// </value>
        public override SteamID SteamID
        {
            get { return ProtoHeader.client_steam_id; }
            set { ProtoHeader.client_steam_id = value; }
        }

        /// <summary>
        /// Gets or sets the target job id for this gc message.
        /// </summary>
        /// <value>
        /// The target job id.
        /// </value>
        public override ulong TargetJobID
        {
            get { return ProtoHeader.job_id_target; }
            set { ProtoHeader.job_id_target = value; }
        }
        /// <summary>
        /// Gets or sets the source job id for this gc message.
        /// </summary>
        /// <value>
        /// The source job id.
        /// </value>
        public override ulong SourceJobID
        {
            get { return ProtoHeader.job_id_source; }
            set { ProtoHeader.job_id_source = value; }
        }


        /// <summary>
        /// Shorthand accessor for the protobuf header.
        /// </summary>
        public CMsgProtoBufHeader ProtoHeader { get { return Header.Proto; } }

        /// <summary>
        /// Gets the body structure of this message.
        /// </summary>
        public BodyType Body { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ClientMsgProtobuf&lt;BodyType&gt;"/> class.
        /// This is a client send constructor.
        /// </summary>
        /// <param name="eMsg">The network message type this gc message represents.</param>
        /// <param name="payloadReserve">The number of bytes to initialize the payload capacity to.</param>
        public ClientGCMsgProtobuf( uint eMsg, int payloadReserve = 64 )
            : base( payloadReserve )
        {
            Body = new BodyType();

            // set our emsg
            Header.Msg = eMsg;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientMsgProtobuf&lt;BodyType&gt;"/> class.
        /// This a reply constructor.
        /// </summary>
        /// <param name="eMsg">The network message type this gc message represents.</param>
        /// <param name="msg">The message that this instance is a reply for.</param>
        /// <param name="payloadReserve">The number of bytes to initialize the payload capacity to.</param>
        public ClientGCMsgProtobuf( uint eMsg, GCMsgBase<MsgGCHdrProtoBuf> msg, int payloadReserve = 64 )
            : this( eMsg, payloadReserve )
        {
            // our target is where the message came from
            Header.Proto.job_id_target = msg.Header.Proto.job_id_source;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientMsgProtobuf&lt;BodyType&gt;"/> class.
        /// This is a recieve constructor.
        /// </summary>
        /// <param name="msg">The packet message to build this gc message from.</param>
        public ClientGCMsgProtobuf( IPacketGCMsg msg )
            : this( msg.MsgType )
        {
            Deserialize( msg.GetData() );
        }

        /// <summary>
        /// Serializes this gc message instance to a byte array.
        /// </summary>
        /// <returns>
        /// Data representing a gc message.
        /// </returns>
        public override byte[] Serialize()
        {
            using ( MemoryStream ms = new MemoryStream() )
            {
                Header.Serialize( ms );
                Serializer.Serialize( ms, Body );
                Payload.WriteTo( ms );

                return ms.ToArray();
            }
        }
        /// <summary>
        /// Initializes this gc message by deserializing the specified data.
        /// </summary>
        /// <param name="data">The data representing a gc message.</param>
        public override void Deserialize( byte[] data )
        {
            using ( MemoryStream ms = new MemoryStream( data ) )
            {
                Header.Deserialize( ms );
                Body = Serializer.Deserialize<BodyType>( ms );

                // the rest of the data is the payload
                int payloadOffset = ( int )ms.Position;
                int payloadLen = ( int )( ms.Length - ms.Position );

                Payload.Write( data, payloadOffset, payloadLen );
            }
        }
    }
}
