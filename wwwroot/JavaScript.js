"use strict";

import * as myModule from "./JavaScriptModules.js";

//IIFE - for testing api call
(async () => {
    try {
        const response = await fetch("https://fakestoreapi.com/products");
        if (response.ok) {
            const data = await response.json();
            console.log(data);

            data.forEach(i => {
                const { category, description, price, title } = i;
                const itemString = `Category=${category}</br> Description=${description}</br> Price=${price}</br> Title=${title}</br></br>`;
            });
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
};