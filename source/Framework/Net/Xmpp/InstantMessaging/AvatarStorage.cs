// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.InstantMessaging.Configuration
{
    /// <summary>
    /// <see cref="XmppSession"/> configuration
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "")]
    [XmlRootAttribute("storage", Namespace = "", IsNullable = false)]
    public sealed class AvatarStorage
    {
        #region · Static Members ·

        private static XmlSerializer    Serializer          = new XmlSerializer(typeof(AvatarStorage));
        private static readonly string  AvatarsDirectory    = "Avatars";
        private static readonly string  AvatarsFile         = "Avatars.xml";

        #endregion

        #region · Static Methods ·

        private static bool ExistsAvatar(string file)
        {
            string filename = AvatarsDirectory + Path.DirectorySeparatorChar + file;

            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (storage.GetDirectoryNames(AvatarsDirectory).Length == 0)
                {
                    storage.CreateDirectory(AvatarsDirectory);
                }

                return (storage.GetFileNames(filename).Length != 0);
            }
        }

        private static byte[] ReadFile(string file)
        {
            string filename = AvatarsDirectory + Path.DirectorySeparatorChar + file;

            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (storage.GetDirectoryNames(AvatarsDirectory).Length == 0)
                {
                    storage.CreateDirectory(AvatarsDirectory);
                }

                using (IsolatedStorageFileStream stream =
                            new IsolatedStorageFileStream(filename, FileMode.OpenOrCreate, storage))
                {
                    byte[] buffer = new byte[stream.Length];

                    stream.Read(buffer, 0, buffer.Length);

                    return buffer;
                }
            }
        }

        #endregion

        #region · Fields ·

        private List<Avatar>    avatars;
        private object          syncObject;

        #endregion

        #region · Properties ·

        [XmlArray("avatars")]
        [XmlArrayItem("avatar", typeof(Avatar))]
        public List<Avatar> Avatars
        {
            get { return this.avatars; }
        }

        #endregion

        #region · Constructor ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppSessionConfiguration"/> class.
        /// </summary>
        public AvatarStorage()
        {
            this.avatars    = new List<Avatar>();
            this.syncObject = new object();
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Gets the avatar hash.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <returns></returns>
        public string GetAvatarHash(string contactId)
        {
            Avatar avatar = this.avatars.Where(a => a.Contact == contactId).SingleOrDefault();
            
            if (avatar != null)
            {
                return avatar.Hash;
            }

            return null;
        }

        /// <summary>
        /// Reads the avatar.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <returns></returns>
        public Stream ReadAvatar(string contactId)
        {
            lock (this.syncObject)
            {
                Avatar avatar = this.avatars.Where(a => a.Contact == contactId).SingleOrDefault();

                if (avatar != null)
                {
                    if (ExistsAvatar(avatar.Hash + ".avatar"))
                    {
                        return new MemoryStream(ReadFile(avatar.Hash + ".avatar"));
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Removes the avatar of the given contact id.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        public void RemoveAvatar(string contactId)
        {
            lock (this.syncObject)
            {
                try
                {
                    this.Avatars.Remove(this.avatars.Where(a => a.Contact == contactId).SingleOrDefault());
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Loads avatars
        /// </summary>
        public void Load()
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (storage.FileExists(AvatarsFile))
                {
                    using (IsolatedStorageFileStream stream =
                                new IsolatedStorageFileStream(AvatarsFile, FileMode.OpenOrCreate, storage))
                    {
                        if (stream.Length > 0)
                        {
                            AvatarStorage avatarStorage = (AvatarStorage)Serializer.Deserialize(stream);

                            this.Avatars.AddRange(avatarStorage.Avatars);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Saves the avatar.
        /// </summary>
        /// <param name="contactId">The contact id.</param>
        /// <param name="hash">The hash.</param>
        /// <param name="avatar">The avatar image.</param>
        public void SaveAvatar(string contactId, string hash, MemoryStream avatarStream)
        {
            lock (this.syncObject)
            {
                // The avatar files should be saved only if it's not in use by another user ( several users can share the same avatar )
                var q = from userAvatar in this.Avatars
                        where userAvatar.Hash == hash
                        select userAvatar;

                try
                {
                    if (q.Count() == 0 && avatarStream.Length > 0)
                    {
                        String avatarFile = String.Format("{0}{1}{2}{3}", AvatarsDirectory, Path.DirectorySeparatorChar, hash, ".avatar");

                        if (!ExistsAvatar(String.Format("{0}{1}", hash, ".avatar")))
                        {
                            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
                            {
                                using (IsolatedStorageFileStream stream =
                                            new IsolatedStorageFileStream(avatarFile, FileMode.Create, storage))
                                {
                                    stream.Write(avatarStream.ToArray(), 0, Convert.ToInt32(avatarStream.Length));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    // Check if the avatar is already added to the list
                    Avatar avatar = this.avatars.Where(a => a.Contact == contactId).SingleOrDefault();

                    if (avatar != null)
                    {
                        // Update the existent avatar information
                        avatar.Hash = hash;
                    }
                    else
                    {
                        // Add the new avatar to the list
                        this.avatars.Add(new Avatar(contactId, hash));
                    }
                }
            }
        }

        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void Save()
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (IsolatedStorageFileStream stream =
                            new IsolatedStorageFileStream(AvatarsFile, FileMode.OpenOrCreate, storage))
                {
                    using (XmlTextWriter xmlWriter = new XmlTextWriter(stream, Encoding.UTF8))
                    {
                        // Writer settings
                        xmlWriter.QuoteChar = '\'';
                        xmlWriter.Formatting = Formatting.Indented;

                        Serializer.Serialize(xmlWriter, this);
                    }
                }
            }
        }

        #endregion
    }
}
