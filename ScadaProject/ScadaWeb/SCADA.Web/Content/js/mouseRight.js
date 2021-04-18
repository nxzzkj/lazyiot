; (function ($, window) {
    $.prototype.mouseRight = function (options, callback) {
        var defaults, settings, me, _this;
        me = this;
        defaults = {
            menu: [{}],
            ele: '#body'
        };
        settings = $.extend({},
        defaults, options);
        $(this).each(function () {
            (function () {
                var parentDiv = $('<div></div>');
                parentDiv.attr('class', 'wrap-ms-right');
                for (let i = 0; i < settings.menu.length; i++) {
                    var childDiv = $('<li></li>');
                    childDiv.addClass('ms-item');
                    var childDiv1 = $('<i></i>');
                    childDiv.attr('data-item', i);
                    childDiv1.addClass(settings.menu[i].icon);
                    childDiv1.attr('data-item', i);
                    childDiv1.appendTo(childDiv);
                    childDiv.appendTo(parentDiv);
                    childDiv1.after('&nbsp; ' + settings.menu[i].itemName)
                }
                parentDiv.prependTo('body');
                var parentShade = $('<div></div>');
                parentShade.attr('class', 'shade');
                parentShade.prependTo('body')
            })();
            window.oncontextmenu = function () {
                return false
            };
            $(settings.ele).mousedown(function (e) {
                if (e.which === 3) {
                    $('.wrap-ms-right').css({
                        'display': 'block',
                        'top': e.pageY + 'px',
                        'left': e.pageX + 'px'
                    });
                    $('.shade').css({
                        'display': 'block'
                    })
                }
            });
            $('.ms-item').click(function (e) {
                var clickID = parseInt($(e.target).attr('data-item'));
                for (let i = 0; i < settings.menu.length; i++) {
                    if (clickID == i) {
                        settings.menu[i].callback();
                        $('.wrap-ms-right').css({
                            'display': 'none'
                        });
                        $('.shade').css({
                            'display': 'none'
                        })
                    }
                }
            });
            $('.shade').click(function () {
                $('.wrap-ms-right').css({
                    'display': 'none'
                });
                $('.shade').css({
                    'display': 'none'
                })
            })
        });
        return this
    }
})(jQuery, window)