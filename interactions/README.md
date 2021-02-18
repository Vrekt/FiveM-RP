# Interactions
NoPixel style like interactions with the 'eye' icon.

- 3 options
- Highlightable
- Easy API

# How to use it (dev)
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

### To listen for option clicks
```csharp
            EventHandlers["interactions:clicked"] += new Action<object>(obj =>
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
