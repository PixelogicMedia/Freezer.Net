using System;
using Gecko;

namespace Freezer.Engines.Gecko
{
    /// <summary>
    /// Used to prevent from displaying certain firefox alerts about unknown protocols.
    /// </summary>
    internal class GeckoPromptServiceMock : nsIPromptService2, nsIPrompt
    {
        public void Alert(nsIDOMWindow aParent, string aDialogTitle, string aText)
        {

            _promptService.Alert( aDialogTitle, aText);
        }

        public void AlertCheck(nsIDOMWindow aParent, string aDialogTitle, string aText, string aCheckMsg, ref bool aCheckState)
        {
  
            _promptService.AlertCheck(aDialogTitle, aText, aCheckMsg, ref aCheckState);
        }

        public bool Confirm(nsIDOMWindow aParent, string aDialogTitle, string aText)
        {
            return _promptService.Confirm(aDialogTitle, aText);
        }

        public bool ConfirmCheck(nsIDOMWindow aParent, string aDialogTitle, string aText, string aCheckMsg,
            ref bool aCheckState)
        {
            return _promptService.ConfirmCheck(aDialogTitle, aText, aCheckMsg, ref aCheckState);
        }

        public int ConfirmEx(nsIDOMWindow aParent, string aDialogTitle, string aText, uint aButtonFlags, string aButton0Title,
            string aButton1Title, string aButton2Title, string aCheckMsg, ref bool aCheckState)
        {
            return _promptService.ConfirmEx(aDialogTitle, aText, aButtonFlags, aButton0Title, aButton1Title,
                aButton2Title, aCheckMsg, ref aCheckState);
        }

        public bool Prompt(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aValue, string aCheckMsg,
            ref bool aCheckState)
        {
            return _promptService.Prompt(aDialogTitle, aText, ref aValue, aCheckMsg, ref aCheckState);
        }

        public bool PromptUsernameAndPassword(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aUsername,
            ref string aPassword, string aCheckMsg, ref bool aCheckState)
        {
            return _promptService.PromptUsernameAndPassword(aDialogTitle, aText, ref aUsername, ref aPassword, aCheckMsg,
                ref aCheckState);
        }

        public bool PromptPassword(nsIDOMWindow aParent, string aDialogTitle, string aText, ref string aPassword,
            string aCheckMsg, ref bool aCheckState)
        {
            return _promptService.PromptPassword( aDialogTitle, aText, ref aPassword, aCheckMsg, ref aCheckState);
        }

        public bool Select(nsIDOMWindow aParent, string aDialogTitle, string aText, uint aCount, IntPtr[] aSelectList,
            ref int aOutSelection)
        {
            return _promptService.Select(aDialogTitle, aText, aCount, aSelectList, ref aOutSelection);
        }

        public bool PromptAuth(nsIDOMWindow aParent, nsIChannel aChannel, uint level, nsIAuthInformation authInfo,
            string checkboxLabel, ref bool checkValue)
        {
            return false;
        }

        public nsICancelable AsyncPromptAuth(nsIDOMWindow aParent, nsIChannel aChannel, nsIAuthPromptCallback aCallback,
            nsISupports aContext, uint level, nsIAuthInformation authInfo,
            string checkboxLabel, ref bool checkValue)
        {
            return null; 
        }

        public void Alert(string dialogTitle, string text)
        {
            return;
        }

        public void AlertCheck(string dialogTitle, string text, string checkMsg, ref bool checkValue)
        {
             _promptService.AlertCheck(dialogTitle, text, checkMsg, ref checkValue);
        }

        public bool Confirm(string dialogTitle, string text)
        {
            return _promptService.Confirm(dialogTitle, text);
        }

        public bool ConfirmCheck(string dialogTitle, string text, string checkMsg, ref bool checkValue)
        {
            return _promptService.ConfirmCheck(dialogTitle, text, checkMsg, ref checkValue);
        }

        public int ConfirmEx(string dialogTitle, string text, uint buttonFlags, string button0Title, string button1Title,
            string button2Title, string checkMsg, ref bool checkValue)
        {
            return _promptService.ConfirmEx(dialogTitle, text, buttonFlags, button0Title, button1Title, button2Title, checkMsg,
                ref checkValue);
        }

        public bool Prompt(string dialogTitle, string text, ref string value, string checkMsg, ref bool checkValue)
        {
            return _promptService.Prompt(dialogTitle, text, ref value, checkMsg, ref checkValue);
        }

        public bool PromptPassword(string dialogTitle, string text, ref string password, string checkMsg, ref bool checkValue)
        {
            return _promptService.PromptPassword(dialogTitle, text, ref password, checkMsg, ref checkValue);
        }

        public bool PromptUsernameAndPassword(string dialogTitle, string text, ref string username, ref string password,
            string checkMsg, ref bool checkValue)
        {
            return _promptService.PromptUsernameAndPassword(dialogTitle, text, ref username, ref password, checkMsg,
                ref checkValue);
        }

        public bool Select(string dialogTitle, string text, uint count, IntPtr[] selectList, ref int outSelection)
        {
            return _promptService.Select(dialogTitle, text, count, selectList, ref outSelection);
        }

        #region Non COM methods

        private static PromptService _promptService = new PromptService();
        #endregion

        #region Filter strings.
        private const string UnknownProtocolFilterString = "Firefox doesn't know how to open this address, because the protocol";

        private const string ProxyErrorFilterString = "Firefox is configured to use a proxy server that can't be found.";
        #endregion
    }
}