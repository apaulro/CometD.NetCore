using System.Collections.Generic;

namespace CometD.NetCore.Bayeux
{
    /// <summary> <p>A Bayeux channel is the primary message routing mechanism within Bayeux:
    /// both Bayeux clients and Bayeux server use channels to group listeners that
    /// are interested in receiving messages with that channel.</p>
    ///
    /// <p>This interface is the common root for both the
    /// {@link org.cometd.bayeux.client.ClientSessionChannel client side} representation
    /// of a channel and the {@link org.cometd.bayeux.server.ServerChannel server side}
    /// representation of a channel.</p>
    ///
    /// <p>Channels are identified with strings that look like paths (e.g. "/foo/bar")
    /// called "channel id".<br/>
    /// Meta channels have channel ids starting with "/meta/" and are reserved for the
    /// operation of they Bayeux protocol.<br/>
    /// Service channels have channel ids starting with "/service/" and are channels
    /// for which publish is disabled, so that only server side listeners will receive
    /// the messages.</p>
    ///
    /// <p>A channel id may also be specified with wildcards.<br/>
    /// For example "/meta/*" refers to all top level meta channels
    /// like "/meta/subscribe" or "/meta/handshake".<br/>
    /// The channel "/foo/**" is deeply wild and refers to all channels like "/foo/bar",
    /// "/foo/bar/bob" and "/foo/bar/wibble/bip".<br/>
    /// Wildcards can only be specified as last segment of a channel; therefore channel
    /// "/foo/&#42;/bar/** is an invalid channel.</p>
    ///
    /// </summary>
    public interface IChannel
    {
        /// <summary>
        /// AttributeNames.
        /// </summary>
        /// <returns> the list of channel attribute names.
        /// </returns>
        ICollection<string> AttributeNames { get; }

        /// <summary>
        /// ChannelId.
        /// </summary>
        /// <returns> The channel ID as a {@link ChannelId}.
        /// </returns>
        ChannelId ChannelId { get; }

        long ReplayId { get; }

        /// <summary>
        /// DeepWild.
        /// </summary>
        /// <returns> true if the channel is deeply wild.
        /// </returns>
        bool DeepWild { get; }

        /// <summary>
        /// Id.
        /// </summary>
        /// <returns> The channel id as a string.
        /// </returns>
        string Id { get; }

        /// <summary>
        /// Meta.
        /// </summary>
        /// <returns> true if the channel is a meta channel.
        /// </returns>
        bool Meta { get; }

        /// <summary>
        /// Service.
        /// </summary>
        /// <returns> true if the channel is a service channel.
        /// </returns>
        bool Service { get; }

        /// <summary>
        /// Wild.
        /// </summary>
        /// <returns> true if the channel is wild.
        /// </returns>
        bool Wild { get; }

        /// <summary> <p>Retrieves the value of named channel attribute.</p></summary>
        /// <param name="name">the name of the attribute.
        /// </param>
        /// <returns> the attribute value or null if the attribute is not present.
        /// </returns>
        object GetAttribute(string name);

        /// <summary> <p>Removes a named channel attribute.</p></summary>
        /// <param name="name">the name of the attribute.
        /// </param>
        /// <returns> the value of the attribute.
        /// </returns>
        object RemoveAttribute(string name);

        /// <summary> <p>Sets a named channel attribute value.</p>
        /// <p>Channel attributes are convenience data that allows arbitrary
        /// application data to be associated with a channel.</p>
        /// </summary>
        /// <param name="name">the attribute name.
        /// </param>
        /// <param name="value">the attribute value.
        /// </param>
        void SetAttribute(string name, object value);
    }
}
