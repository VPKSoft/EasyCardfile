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

using System.Windows.Forms;
using EasyCardFile.Database.Entity.Entities;
using VPKSoft.LangLib;

namespace EasyCardFile.UtilityClasses.Miscellaneous.Dialogs
{

    /// <summary>
    /// A dialog to select an image for a card type.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms"/>
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogSelectImageArea : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyCardFile.UtilityClasses.Miscellaneous.Dialogs.FormDialogSelectImageArea"/> class.
        /// </summary>
        public FormDialogSelectImageArea()
        {
            InitializeComponent();

            // ReSharper disable once StringLiteralTypo
            DBLangEngine.DBName = "localization.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitializeLanguage("EasyCardFile.UtilityClasses.Localization.Messages",
                    Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            // initialize the language/localization database..
            DBLangEngine.InitializeLanguage("EasyCardFile.UtilityClasses.Localization.Messages");
        }

        private CardType CardType { get; set; }

        /// <summary>
        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// </summary>
        /// <param name="owner">Any object that implements <see cref="T:System.Windows.Forms.IWin32Window" /> that represents the top-level window that will own the modal dialog box. </param>
        /// <param name="cardType">Type of the card to select an image for.</param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.ArgumentException">The form specified in the <paramref name="owner" /> parameter is the same as the form being shown.</exception>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        public static DialogResult ShowDialog(IWin32Window owner, CardType cardType)
        {
            var form = new FormDialogSelectImageArea {CardType = cardType};
            return form.ShowDialog();
        }

        private void FormDialogSelectImageArea_Shown(object sender, System.EventArgs e)
        {
            Text = DBLangEngine.GetMessage("msgSelectCardImageTitle",
                "Select an image for the card type '[{0}]'|A title for a dialog to select a part of an image to be used with a card type.");

        }
    }
}
