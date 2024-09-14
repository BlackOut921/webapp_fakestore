"use strict";

async function GetProducts() {
    try {
        const response = await fetch("https://fakestoreapi.com/products");
        if (response.ok) {
            const data = await response.json();

            //Clothing
            const mens = data.filter(i => i.category === "men's clothing");
            console.log(mens);
            const womens = data.filter(i => i.category === "women's clothing");
            console.log(womens);

            //Jewelery
            const jewelery = data.filter(i => i.category === "jewelery");
            console.log(jewelery);

            //Electronics
            const electronics = data.filter(i => i.category === "electronics");
            console.log(electronics);
        }
        else {
            throw new Error("Request error");
        }
    }
    catch (e) {
        console.log(e);
    }
}

window.onload = () => {
    GetProducts();
};