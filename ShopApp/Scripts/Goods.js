$(document).ready(function () {
    $('#loadGoods').click(function () {
        Goods.getGoods();
    });
});

Goods = {
    getGoods: function () {
        $.ajax(
            {
                asynh: true,
                url: "/Home/Goods",
                success: function (output, status, xhr) {
                    Goods.parseGoods(output);
                },
                error: function () {
                    alert("Error");
                }
            }
            );
    },       

    deleteGood: function () {
        var id = $(this).attr('id');

        $.ajax(
            {
                asynh: true,
                url: "/Home/Delete/" + id,
                success: function (output) {
                    Goods.getGoods();
                },
                error: function () {
                    alert("Error");
                }
            });
    },

    parseGoods: function (goods) {
        var result = "<table>";
        result += "<tr>";
        result += "<td>Name</td>";
        result += "<td>Amount</td>";
        result += "<td>Bar-code</td>";
        result += "</tr>";
        for (var i = 0; i < goods.length; i++) {
            result += "<tr>";
            result += "<td>" + goods[i].Name + "</td>";
            result += "<td>" + goods[i].Amount + "</td>";
            result += "<td>" + goods[i].BarCode + "</td>";
            //result += "<td>" + "<input type='button' value='delete' class='deleteBtn' id='" + goods[i].Id + "'></td>";
            result += "<td>" + "<a href='#' class='deleteEdit' id='" + goods[i].Id + "'>Delete</a>";
            result += "<td>" + "<a href='/Home/Edit/" + goods[i].Id + "'>Edit</a>";
            result += "</tr>";
        }
        result += "</table>";
        document.getElementById("goods").innerHTML = result;

        $('.deleteEdit').click(Goods.deleteGood);
    }
}