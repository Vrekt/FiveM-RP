window.addEventListener('message', (event) => {
    switch (event.data.type) {
        case 'show':
            show()
            break;
        case 'hide':
            hide()
            break;
        case 'highlight':
            highlight(event.data.state);
            break;
        case 'option':
            option(event.data.option, event.data.text);
            break;
        case 'reset':
            reset()
            break;
    }
})

/**
 * If the interaction is showing
 * @type {boolean} state
 */
let showing = false;

/**
 * The current resource using the interaction
 */
let resource;

/**
 * The shape element
 */
let element;

/**
 * If the element is highlighted
 * @type {boolean} state
 */
let highlighted = false;

/**
 * Show the interaction
 */
function show() {
    document.body.style.visibility = 'visible';
}

/**
 * Hide the interaction
 */
function hide() {
    document.body.style.visibility = 'hidden';
    document.getElementById('options').style.visibility = 'hidden';
    showing = false;
}

/**
 * Show or hide highlight
 * @param state the state
 */
function highlight(state) {
    if (element === undefined) element = document.getElementById('shape');
    element.style.setProperty('--border-color', (state === "True" ? 'steelblue' : '#000'));

    highlighted = (state === "True");
}

/**
 * Set option text
 * @param option the option number
 * @param text the text
 */
function option(option, text) {
    document.getElementById(option).textContent = text;
}

/**
 * Reset option texts
 */
function reset() {
    option(1, "")
    option(2, "")
    option(3, "")
}

/**
 * Show the interaction options
 */
function interactionClicked() {
    if (highlighted) {
        document.getElementById('options').style.visibility = showing ? 'hidden' : 'visible';
        showing = !showing;
    }
}

/**
 * Invoked on option click
 * @param option the option number
 */
function onOptionClicked(option) {
    fetch(`https://${GetParentResourceName()}/clicked`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=UTF-8',
        },
        body: JSON.stringify({
            option: option
        })
    }).then()
}