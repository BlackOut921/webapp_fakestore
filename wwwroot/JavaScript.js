"use strict";

import * as myModule from "./JavaScriptModules.js";

//IIFE - for testing api call
(async () => {
    try {
        const response = await fetch("https://fakestoreapi.com/products");
        if (response.ok) {
            const data = await response.json();
        }
        else {
            throw new Error("Request error");
        }
    }
    catch (e) {
        console.log(e);
    }
})();

window.onload = () => {
    const _observer = new IntersectionObserver(items =>
        items.forEach(i => i.isIntersecting && i.target.classList.add("show")));
    const _observerTargets = document.querySelectorAll(".observer-target");
    _observerTargets.length > 0 && _observerTargets.forEach(i => _observer.observe(i));

    //-----------------------------------
    //Print to console if bTest option is true
    const Test = (options) => options.bTest && console.log(`bTest=${options.bTest}`);
    Test({ bTest: true }); //Options objects { options }
    //-----------------------------------

    //Dynamically modify datalist options
    //Catch search queries?? Cookies?? LocalStorage??
    const dlKeywordsElement = document.getElementById("dlKeywords");
    const dlKeywordsOptions = ["test", "product", 921];
    dlKeywordsOptions.length > 0 && dlKeywordsOptions.forEach(i => {
        const newOption = document.createElement("option");
        newOption.value = i.toString();
        dlKeywordsElement.appendChild(newOption);
    });
};