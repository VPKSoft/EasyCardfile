﻿#region License
/*
MIT License

Copyright(c) 2020 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System.Collections.Generic;
using EasyCardFile.CardFileHandler;
using VPKSoft.Utils;
using VPKSoft.Utils.XmlSettingsMisc;

namespace EasyCardFile.Settings
{
    /// <summary>
    /// A class for the application settings.
    /// Implements the <see cref="VPKSoft.Utils.XmlSettings" />
    /// </summary>
    /// <seealso cref="VPKSoft.Utils.XmlSettings" />
    public class Settings: XmlSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the existing card files are auto saved upon software close.
        /// </summary>
        [IsSetting(DefaultValue = true)]
        public bool AutoSave { get; set; }

        /// <summary>
        /// Gets or sets the session files.
        /// </summary>
        [IsSetting]
        public List<string> SessionFiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to restore the session on application startup.
        /// </summary>
        [IsSetting(DefaultValue = true)]
        public bool RestoreSessionOnStartup { get; set; }

        /// <summary>
        /// Gets or sets the index of the session active tab.
        /// </summary>
        [IsSetting]
        public int SessionActiveTabIndex { get; set; }

        /// <summary>
        /// Sets the files belonging to the current session.
        /// </summary>
        /// <param name="tabControl">The tab control witch the active card files reside.</param>
        public void SetSessionFiles(Manina.Windows.Forms.TabControl tabControl)
        {
            SessionFiles = new List<string>();

            foreach (var tab in tabControl.Tabs)
            {
                var wrapper = CardFileUiWrapper.GetWrapperByTab(tab);

                if (wrapper == null)
                {
                    continue;
                }

                if (!wrapper.IsTemporary)
                {
                    SessionFiles.Add(wrapper.FileName);
                }
            }
        }
    }
}
