$(function() {
    UnableToPurchase();

    $('.form-control').click(function() {
        var hashtable = {};
        hashtable['Select'] = '0';
        hashtable['Vanilla Ice Cream with Caramel Ripple and Almonds'] = '5';
        hashtable['Vanilla Ice Cream with Cherry Dark Chocolate Ice Cream'] = '7';
        hashtable['Vanilla Ice Cream with Pistachio'] = '4.5';

        var hashtableImages = {};
        hashtableImages['Select'] = '0';
        hashtableImages['Vanilla Ice Cream with Caramel Ripple and Almonds'] = 'icecream-1.jpg';
        hashtableImages['Vanilla Ice Cream with Cherry Dark Chocolate Ice Cream'] = 'icecream-2.jpg';
        hashtableImages['Vanilla Ice Cream with Pistachio'] = 'icecream-3.jpg';

        var iceCreanQuantity = parseFloat($("#quantity").val());
        var iceCreamFlavor = $("#flavor").val();
        var priceperweight = parseFloat(hashtable[iceCreamFlavor]);
        var iceCreamImage = hashtableImages[iceCreamFlavor];
        var calc = (iceCreanQuantity * priceperweight);

        if (calc && iceCreamImage !== 0) {
            $('#totalAmount').html(calc + '$');
            var src = '/images/' + iceCreamImage;
            $("#iceCreamImage").attr("src", src);
            $("#formButton").removeAttr('disabled');
        } else {
            UnableToPurchase();
        }
    });

    function UnableToPurchase() {
        $('#totalAmount').html('');
        $("#iceCreamImage").attr("src", '/images/empty.jpg');
        $("#formButton").attr('disabled', 'disabled');
    }
});
