# Interactions
NoPixel style like interactions with the 'eye' icon.

- 3 options
- Highlightable
- Easy API

<img src="https://i.imgur.com/VboENgQ.png">

# How to use it (dev)

### Config
By default the interaction is automatically shown for you based on the key you set in the fxmanifest.lua.

You can manually show or hide the interaction like so:
```csharp
Exports["interactions"].show();
Exports["interactions"].hide();
```
                

### To highlight the interaction eye icon
For example, if the player is infront of a interactable ped.

```csharp
// highlight
Exports["interactions"].highlight(true);
// remove highlight
Exports["interactions"].highlight(false);
```

### To change the options that are shown
```csharp
Exports["interactions"].option(1, "Do something");
Exports["interactions"].option(2, "Do something else");
```

### To reset options
```csharp
Exports["interactions"].reset();
```

### To listen for option clicks

The event for option clicks is `interactions:clicked_OPTIONNUMBER`, for example `interactions:clicked_1`, `interactions:clicked_2` etc.

```csharp
            EventHandlers["interactions:clicked_1"] += new Action<object>(obj =>
            {
                var optionClicked = (int) obj;
                if (optionClicked == 1)
                {
                    Option1Clicked();
                } else if (optionClicked == 2)
                {
                    Option2Clicked();
                }
            }); 
```
