


const cookieName = "cart_Item";

function AddToCart(id, name, price, picture, slug) {

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
            doublePrice: price,
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
    $("#cart_items_count").text(Products.length);
    const cartitemwrapper = $("#cart_items_wrapper");
    cartitemwrapper.html('');
    Products.forEach(c => {
        const product = `<div class="single-cart-item" >
                           <a href="#" onclick="removeFromCart('${c.id}')" class="remove-icon">
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
                              <p class="count"> قیمت واحد (تومان) : ${c.doublePrice} </p>
                           </div>
                       </div>`;

        cartitemwrapper.append(product);
    });
}




function removeFromCart(id) {

    let Products = $.cookie(cookieName);
    Products = JSON.parse(Products);
    const itemtoremove = Products.findIndex(c => c.id === id);
    Products.splice(itemtoremove, 1);
    $.cookie(cookieName, JSON.stringify(Products), { expires: 2, path: "/" })
    updateCart();
}


function changeCartItemCount(id, totalId, count) {
    var products = $.cookie(cookieName);
    products = JSON.parse(products);
    const productIndex = products.findIndex(x => x.id == id);
    products[productIndex].count = count;
    const product = products[productIndex];
    const newPrice = parseInt(product.doublePrice) * parseInt(count);
    $(`#${totalId}`).text(newPrice);
    //products[productIndex].totalPrice = newPrice;
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();


    const settings = {
        "url": "https://localhost:44374/api/inventory",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({ "ProductId": id, "Count": count })
    };

    $.ajax(settings).done(function (data) {
        if (data.isStock == false) {
            const warningsDiv = $('#productStockWarnings');
            if ($(`#${id}`).length == 0) {
                warningsDiv.append(`
                    <div class="alert alert-warning" id="${id}">
                        <i class="fa fa-warning"></i> کالای
                        <strong>${data.productName}</strong>
                        در انبار کمتر از تعداد درخواستی موجود است.
                    </div>
                `);
            }
        } else {
            if ($(`#${id}`).length > 0) {
                $(`#${id}`).remove();
            }
        }
    });

}


