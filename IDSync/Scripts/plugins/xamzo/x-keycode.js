!function($) {
    $(function() {
        $('html').on('hover', '[data-tabindex="true"]', function(e) {
            var col = ($(this).attr('data-coll')) ? parseInt($(this).attr('data-coll')) : 1;
            var t = $(this).find('input:not([type="hidden"],[readonly]),textarea');
            setInterval(function() {
                t.each(function(i, el) {
                    $(el).attr('tabindex', parseInt(i + 1));
                });
            }, 1000);
            t.on("keydown", function(e) {
                var current = parseInt($(this).attr('tabindex'));
                (e.keyCode) ? key = e.keyCode : key = e.which;
                switch (key) {
                    case 37:
                        next = current - 1;
                        break; 		//left
                    case 38:
                        next = current - col;
                        break; 		//up
                    case 39:
                        next = (1 * current) + 1;
                        break; 	//right
                    case 40:
                        next = (1 * current) + col;
                        break; 	//down
                }

                function cursor() {
                    if ($('input[tabindex="' + next + '"]').length > 0) {
                        $('input[tabindex="' + next + '"]').focus().css({
                            'background': 'rgb(228, 250, 228)'
                        });
                    } else {
                        $('textarea[tabindex="' + next + '"]').focus().css({
                            'background': 'rgb(228, 250, 228)'
                        });
                    }
                }
                if (key === 37 | key === 38 | key === 39 | key === 40) {
                    $('input, textarea').removeAttr('style');
                    var attr = $('input[tabindex="' + next + '"]').attr('autocomplete');
                    if (typeof attr !== 'undefined' && attr !== false) {
                        if (key === 37 | key === 39) {
                            cursor();
                        }
                    } else {
                        cursor();
                    }
                    current = next;
                }

            });
        });
    });
}(window.$);
 