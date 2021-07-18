


const cookieName = "cart_Item";

function AddToCart(id, name, price, picture,slug) {

    let Products = $.cookie(cookieName);
    if (Products === undefined) {
        Products = [];

    } else {
        Products = JSON.parse(Products);
    }
    const count = $("#productCount").val();
    const currentProduct = Products.find(c => c.id === id);
    if (currentProduct !== undefined) {
        Products.find(c => c.id === id).count = parseInt(currentProduct.count) + parseInt(count);

    } else {
        const product = {
            id,
            name,
            UnitPrice:price,
            picture,
            slug,
            count
        }
        Products.push(product);
    }

    $.cookie(cookieName, JSON.stringify(Products), { expires: 2, path: "/" })
    updateCart();
}


function updateCart() {

    let Products = $.cookie(cookieName);
    Products = JSON.parse(Products);
    $("#cart_Items_count").text(Products.length);
    let cartitemwrapper = $("#cart_Items_wrapper");
    cartitemwrapper.html('');
    Products.forEach(c => {

        const product = `<div class="single-cart-item" >
                           <a onclick="removeFromcart('${c.id}')" class="remove-icon">
                               <i class="ion-android-close"></i>
                           </a>
                           <div class="image">
                               <a href="#">
                                   <img src="/ProductPicture/${c.picture}"
                                        class="img-fluid" alt="">
                               </a>
                           </div>
                           <div class="content">
                               <p class="product-title">
                                   <a href="/Product/${c.slug}">محصول : ${c.name}</a>
                               </p>
                               <p class="count">تعداد : ${c.count}</p>
                               <p class="count">قیمت : ${ToRial(c.UnitPrice)} </p>
                           </div>
                       </div>`;


        cartitemwrapper.append(product);
    });
}


function removeFromcart(id) {

    let Products = $.cookie(cookieName);
    Products = JSON.parse(Products);
    let itemtoremove = Products.findIndex(c => c.id === id);
    Products.splice(itemtoremove, 1);
    $.cookie(cookieName, JSON.stringify(Products), { expires: 2, path: "/" })
    updateCart();
}


function ToRial(str) {

    str = str.replace(/\,/g, '');
    var objRegex = new RegExp('(-?[0-9]+)([0-9]{3})');

    while (objRegex.test(str)) {
        str = str.replace(objRegex, '$1,$2');
    }

    return str;
}