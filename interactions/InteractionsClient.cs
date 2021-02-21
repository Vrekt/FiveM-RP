using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using static BasicJson.NuiJson;

namespace interactions2
{
    [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
    public class InteractionsClient : BaseScript
    {
        /// <summary>
        /// Configuration values
        /// </summary>
        private bool _listenForInteraction, _giveNuiFocus;

        /// <summary>
        /// Configuration values
        /// </summary>
        private int _interactionKey, _delay;

        /// <summary>
        /// If the interaction is being shown.
        /// </summary>
        private bool _isShowingInteraction;

        /// <summary>
        /// Invoked when the interactions resource is started.
        /// </summary>
        /// <param name="resourceName">the resource name</param>
        [EventHandler("onClientResourceStart")]
        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            LoadConfiguration(resourceName);
            RegisterExports();
            RegisterCallbacks();
        }

        /// <summary>
        /// Load the basic configuration from manifest
        /// </summary>
        private void LoadConfiguration(string resourceName)
        {

            _listenForInteraction =
                bool.Parse(GetResourceMetadata(resourceName, "listen_for_interaction_key", 0));
            _interactionKey = int.Parse(GetResourceMetadata(resourceName, "interaction_key", 0));
            _delay = int.Parse(GetResourceMetadata(resourceName, "delay", 0));
            _giveNuiFocus = bool.Parse(GetResourceMetadata(resourceName, "give_nui_focus", 0));

            if (_listenForInteraction)
            {
                // register tick.
                Tick += PollInput;
            }
        }

        /// <summary>
        /// Register the exports
        /// </summary>
        private void RegisterExports()
        {
            Exports.Add("show", new Action(ShowInteraction));
            Exports.Add("hide", new Action(HideInteraction));
            Exports.Add("highlight", new Action<bool>(Highlight));
            Exports.Add("option", new Action<int, string>(SetOption));
            Exports.Add("reset", new Action(Reset));
        }

        /// <summary>
        /// Register NUI callbacks.
        /// </summary>
        private static void RegisterCallbacks()
        {
            RegisterNuiCallbackType("clicked");
        }

        [EventHandler("__cfx_nui:clicked")]
        private void OnNuiClicked(Dictionary<string, object> data, CallbackDelegate cb) 
        {
            if (data.TryGetValue("option", out var option))
            {
                TriggerEvent("interactions:clicked_" + option, option);
            }
            else
            {
                cb("error");
            }

            cb("ok");
        }

        /// <summary>
        /// Show the interaction
        /// </summary>
        private void ShowInteraction()
        {
            if (_giveNuiFocus) SetNuiFocus(true, true);
            SendNuiMessage(CreateTypedNui("show"));
        }

        /// <summary>
        /// Hide the interaction
        /// </summary>
        private void HideInteraction()
        {
            if (_giveNuiFocus) SetNuiFocus(false, false);
            SendNuiMessage(CreateTypedNui("hide"));
        }

        /// <summary>
        /// Hide or show the highlight
        /// </summary>
        /// <param name="state">the state</param>
        private static void Highlight(bool state)
        {
            SendNuiMessage(CreateTypedNuiParam("highlight", "state", state));
        }

        /// <summary>
        /// Set an option
        /// </summary>
        /// <param name="option">the option number</param>
        /// <param name="text">the text</param>
        private static void SetOption(int option, string text)
        {
            SendNuiMessage(CreateTypedNuiParams("option", new Dictionary<string, object>
            {
                {"option", option},
                {"text", text}
            }));
        }

        /// <summary>
        /// Reset options
        /// </summary>
        private static void Reset()
        {
            SendNuiMessage(CreateTypedNui("reset"));
        }

        /// <summary>
        /// Poll input
        /// </summary>
        /// <returns>a task</returns>
        private async Task PollInput()
        {
            await Delay(_delay);

            switch (IsControlPressed(0, _interactionKey))
            {
                case true when !_isShowingInteraction:
                    _isShowingInteraction = true;
                    ShowInteraction();
                    break;
                case false when _isShowingInteraction:
                    _isShowingInteraction = false;
                    HideInteraction();
                    break;
            }
        }
    }
}