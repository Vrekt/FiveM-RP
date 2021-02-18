fx_version 'cerulean'
game 'gta5'

author 'Vrekt'
description 'A resource for managing in-game interactions.'
version '2.0'

client_script 'interactions.net.dll'

ui_page './ui/ui.html'

files {
    'Newtonsoft.Json.dll',
    'BasicJson.dll',
    './ui/ui.html',
    './ui/style.css',
    './ui/script.js',
}

-- If the script should listen for the interaction key.
listen_for_interaction_key 'true'
-- The interaction key number, default: 19 == alt
interaction_key '19'
-- The delay between for the input tick in millis. (Reduce general script load.)
delay '500'
-- If NUI focus should be given when the interaction key is pressed
give_nui_focus 'true'