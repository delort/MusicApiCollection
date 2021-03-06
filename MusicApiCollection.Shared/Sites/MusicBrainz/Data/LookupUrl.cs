#region Copyright (C) 2015-2016 BigGranu
/*
    Copyright (C) 2015-2016 BigGranu

    This file is part of mInfo <https://github.com/BigGranu/MusicApiCollection>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System.Xml.Serialization;
using MusicApiCollection.Events;

namespace MusicApiCollection.Sites.MusicBrainz.Data
{
    /// <remarks/>
    [XmlType(AnonymousType = true, Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    [XmlRoot("metadata", Namespace = "http://musicbrainz.org/ns/mmd-2.0#", IsNullable = false)]
    public class LookupUrl
    {
        private static readonly Exceptions Exceptions = Exceptions.GetInstance();

        /// <summary>
        ///     All possible Data
        /// </summary>
        [XmlElement("url")]
        public LookupUrlResult Data = new LookupUrlResult();

        /// <summary>
        ///     Error Message
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;

        /// <summary>
        ///     Is an Error occurred
        /// </summary>
        public bool ErrorOccurred;

        /// <summary>
        ///     Response
        /// </summary>
        public string Response { get; set; } = string.Empty;

        /// <summary>
        ///     Create new LookupWork and clear the log
        /// </summary>
        public LookupUrl()
        {
            Logging.Clear();
        }

        /// <summary>
        ///     Create new LookupWork with Result
        /// </summary>
        /// <param name="data">Result</param>
        public LookupUrl(LookupUrlResult data)
        {
            Data = data;
            ErrorMessage = Exceptions.Message;
            ErrorOccurred = Exceptions.ErrorOccurred;
            Response = Http.LastResponse;
        }
    }

    /// <remarks/>
    [XmlType(AnonymousType = true, Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class LookupUrlResult
    {
        /// <remarks />
        [XmlElement("resource")]
        public string Resource { get; set; } = string.Empty;

        /// <remarks/>
        [XmlAttribute("id")]
        public string Id { get; set; } = string.Empty;
    }
}