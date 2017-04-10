/*!
 *  xamzo Javascript Wrapper 1.0.0
 *  -------------------------------------------------------
 *  The javascript of xamzo back end applications
 *
 *  License
 *  -------------------------------------------------------
 *  - xamzo wrapper are licensed under the MIT License -
 *    http://opensource.org/licenses/mit-license.html
 *  - http://xamzo.com/license/
 *  
 *  Writer
 *  -------------------------------------------------------
 *  - xamzo wrapper originally writed by Nugroho Rahmat Hadi Wibowo (hadinug)
 *  - visit doc.xamzo.com or www.hadinug.net
 *
 *  Contactof
 *  -------------------------------------------------------
 *  Link: http://xamzo.com
 *  Copyright (c) 2013, xamzo, Inc.
 */

/**
 * define variable init
 */

var loading_ = '<div class="cube">' +
                        '<div class="ani1">' +
                          '<div class="front"><i></i><i></i><i></i></div>' +
                          '<div class="left"><i></i><i></i><i></i></div>' +
                        '</div>' +
                        '<div class="ani2">' +
                          '<div class="front"><i></i><i></i><i></i></div>' +
                          '<div class="bottom"><i></i><i></i><i></i></div>' +
                        '</div>' +
                        '<div class="ani3">' +
                          '<div class="front"><i></i><i></i><i></i></div>' +
                          '<div class="right"><i></i><i></i><i></i></div>' +
                        '</div>' +
                        '<div class="ani4">' +
                          '<div class="front"><i></i><i></i><i></i></div>' +
                          '<div class="top"><i></i><i></i><i></i></div>' +
                        '</div>' +
                        '<div class="shadow"></div>' +
                    '</div>',
                    animate_ = 'none', base_ = '/', wrapper_ = '.x-right', default_title = "IDSync+";
/**
 * 
 * make text area tobe auto height with define attribute class : text-auto
 */
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
    // auto adjust the height of
    $('html').on('keyup', 'textarea.x-textarea', function (e) {
        $(this).css({
            'height': 'auto',
            'overflow': 'hidden'
        });
        $(this).height(this.scrollHeight);
    });
    $('html').on('focus', 'textarea.x-textarea', function (e) {
        $(this).css({
            'height': 'auto',
            'overflow': 'hidden'
        });
        $(this).height(this.scrollHeight);
    });
    $('html').on('click', 'textarea.x-textarea', function (e) {
        $(this).css({
            'height': 'auto',
            'overflow': 'hidden'
        });
        $(this).height(this.scrollHeight);
    });
    $('html').find('textarea.x-textarea').keyup();
});
$(window).keydown(function (event) {
    if (event.keyCode === 123 || (event.ctrlKey && event.keyCode === 85)) {
        event.preventDefault();
    }
});
$(window).keydown(function (event) {
    if (event.ctrlKey && event.keyCode === 72) {
        var hs = '',
                hash = '';
        var val = i.value;
        if (window.location.hash) {
            hs = window.location.hash.substring(1);
            hash = hs.replace('/', '-');
        }
        load(hash, '.x-right');
        event.preventDefault();
    }
});
function _set_check(_ck) {
    if ($(_ck).prop("checked") == true) {
        $(_ck).prop('checked', true).parent().removeClass('checked');
        $(_ck).removeAttr('checked').parent().parent().parent().css({
            'opacity': '1',
            'background': 'transparent'
        });
    } else {
        $(_ck).prop('checked', true).parent().addClass('checked');
        $(_ck).prop('checked', true).parent().parent().parent().css({
            'opacity': '0.6',
            'background': '#fffccc'
        });
    }
    if ($(_ck).parent().find("tr input[checked='true']").length === 0) {
        $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').removeAttr('disabled');
    } else {
        $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').prop('disabled', true);
    }
}
function _crud_cek() {
    if ($('body').find("td input:checked").length > 0) {
        $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').removeAttr('disabled');
    } else {
        $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').prop('disabled', true);
    }
}
// set chek table
function _self_check(_ck) {
    var lcek = $('body').find("input:checked").length;
    if ($(_ck).prop('checked') == true) {
        $(_ck).parent().parent().parent().parent().css({
            'opacity': '0.6',
            'background': '#fffccc'
        });
    } else {
        $(_ck).parent().parent().parent().parent().css({
            'opacity': '1',
            'background': 'transparent'
        });
    }
    if (lcek > 0) {
        $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').removeAttr('disabled');
    } else {
        $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').prop('disabled', true);
    }

}
!function ($) {
    $(function () {
        $('html').on('click', "[type='checkbox']", function (e) {
            var $this = $(this);
            if ($this.parent().parent().attr('table-check-this') !== undefined) {
                _set_check(this);
                _crud_cek();
            }
        });
        $('html').on('click', '[table-check-this]', function (e) {
            var $this = $(this), _ck = $this.find("[type='checkbox']");
            _set_check(_ck);
            _crud_cek();
        });
        $('html').on('click', '[table-check-all]', function (e) {
            var $this = $(this), _parent = $this.parent().parent().parent().parent();
            if ($this.hasClass('btn-primary')) {
                if ($this.hasClass('checked')) {
                    $this.removeClass('checked')
                    _parent.find("tr input, li input").removeAttr('checked');
                    $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').removeAttr('disabled');

                    //opacity
                    var all = $(_parent).find("[type='checkbox']:not([table-check-all='true'])");
                    all.removeAttr('checked');
                    all.parent().parent().click();
                    all.parent().addClass('checked');
                } else {
                    $this.addClass('checked')
                    _parent.find("tr input, li input").prop('checked', true);
                    $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').attr('disabled', true);

                    //opacity
                    var all = $(_parent).find("[type='checkbox']:not([table-check-all='true'])");
                    all.removeAttr('checked');
                    all.parent().parent().parent().css({
                        'background': 'transparent',
                        'opacity': '1'
                    });
                    all.parent().removeClass('checked');
                }
            }
        });
        $('html').on('click', '[crud-name=check]', function (e) {
            var ck = $('input[table-check-all="true"]'),
                    _parent = ck.parent().parent().parent().parent().parent();
            var all = $(_parent).find("[type='checkbox']:not([table-check-all='true'])");
            var x = all.parent().parent().parent().parent();
            if (ck.prop('checked') == true) {
                ck.removeAttr('checked');
                x.css({
                    'background': 'transparent',
                    'opacity': '1'
                });
            } else {
                ck.prop('checked', true);
                x.click();
            }


        });
        $('html').on('click', '[crud-name=list],[crud-name=create]', function (e) {
            $('[crud-name=check]').removeAttr('disabled');
            $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').prop('disabled', true);
        });
        $('html').on('click', '[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]', function (e) {
            var $this = $(this),
                    _act_url = $this.attr('crud-url'),
                    _socket = ($this.attr('socket') != '') ? $this.attr('socket') : 'false',
                    _crud_data = $this.attr('crud-data'),
                    _crud_redirect = $this.attr('crud-redirect'),
                    _crud_target = $this.attr('crud-target'),
                    _act_name = $this.attr('crud-name'),
                    _modal_width = $this.attr('modal-width'),
                    _table_taget = $this.attr('crud-table-target');
            if ($(_table_taget + " td input:checked, " + _table_taget + " input:checked").length === 0) {
                notive("Please Check One");
            } else {
                if ($(_table_taget + " td input:checked, " + _table_taget + " input:checked").length > 1 && _act_name === 'update') {
                    notive("Please Check One");
                } else {
                    switch (_act_name) {
                        case 'delete':
                        case 'group-delete':
                            o_str_ = '<div class="modal-header header-color">' +
                                    '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                    '<h4 class="modal-title">Confirmation</h4>' +
                                    '</div>' +
                                    '<div class="modal-body">';
                            _message_ = '<p>Are you sure to delete the data selected</p>';
                            f_str = '<div class="modal-footer">' +
                                    '<a href="javascript:void(0)" class="btn btn-default btn-sm" onclick="close_box()">Cancel</a>' +
                                    '<button class="btn medium btn-danger btn-sm" id="btn-del" onclick="$(this).html(\'please wait..\');_post(\'' + _socket + '\',\'' + _crud_data + '\',\'true\',\'' + _act_url + '\',undefined,\'' + _crud_redirect + '\',\'' + _crud_target + '\')">Yes</button>';
                            c_str_ = '</div>';
                            return_modalbox(o_str_ + _message_ + c_str_ + f_str, 'true', '400px');
                            break;
                        case 'void':
                            o_str_ = '<div class="modal-header header-color">' +
                                    '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                    '<h4 class="modal-title">Confirmation</h4>' +
                                    '</div>' +
                                    '<div class="modal-body">';
                            _message_ = '<p>Are you sure to void the data selected</p>';
                            f_str = '<div class="modal-footer">' +
                                    '<a href="javascript:void(0)" class="btn btn-default btn-sm" onclick="close_box()">Cancel</a>' +
                                    '<button class="btn medium btn-primary" id="btn-void" onclick="_post(\'' + _socket + '\',\'' + _crud_data + '\',\'true\',\'' + _act_url + '\',undefined,\'' + _crud_redirect + '\',\'' + _crud_target + '\')">Yes</button>';
                            c_str_ = '</div>';
                            return_modalbox(o_str_ + _message_ + c_str_ + f_str, 'true', '400px');
                            $('button#btn-void').focus();
                            break;
                        default:
                            if (_crud_target === 'modalbody') {
                                _post(_socket, _crud_data, 'false', _act_url, true, undefined, _crud_target, undefined, 'false', _modal_width);
                            } else {
                                _post(_socket, _crud_data, 'true', _act_url, true, undefined, _crud_target);
                            }
                            $('[crud-name=delete],[crud-name=group-delete],[crud-name=void],[crud-name=update]').attr('disabled', 'disabled');
                            break;
                    }

                }

            }
        });
        // confirm post
        $('html').on('click', '[crud-name=confirm-post]', function (e) {
            e.preventDefault();
            var $this = $(this)
                    , _url = ($this.attr('ajax-url')) ? $this.attr('ajax-url') : $this.attr('href')
                    , _target = $this.attr('ajax-target')
                    , _meth = ($this.attr('ajax-method')) ? $this.attr('ajax-method') : undefined
                    , _data = $this.attr('ajax-data')
                    , _is_close_box = ($this.attr('is_close_box')) ? $this.attr('is_close_box') : 'true'
                    , _url_redirect = ($this.attr('ajax-redirect')) ? $this.attr('ajax-redirect') : ''
                    , _is_iframe = ($this.attr('ajax-iframe')) ? $this.attr('ajax-iframe') : 'false'
                    , ajax_title = ($this.attr('ajax-title')) ? $this.attr('ajax-title') : $('html').find('title').html()
                    , _url_push = ($this.attr('url-push')) ? $this.attr('url-push') : 'false'
                    , _is_fix = ($this.attr('modal-fix')) ? $this.attr('modal-fix') : 'true'
                    , _isSocket = ($this.attr('socket')) ? $this.attr('socket') : 'false'
                    , _width = ($this.attr('modal-width')) ? $this.attr('modal-width') : '50%';
            o_str_ = '<div class="modal-header header-color">' +
                        '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                        '<h4 class="modal-title">Confirmation</h4>' +
                     '</div>' +
                     '<div class="modal-body">';
            _message_ = '<p>Are you sure to continue the process</p>';
            f_str = '<div class="modal-footer">' +
                       '<button class="btn medium btn-primary" id="btn-confirm" onclick="_confirm_post(this,\'' + _isSocket + '\',\'' + _data + '\',\'' + _is_close_box + '\',\'' + _url + '\',\'' + _url_push + '\',\'' + _url_redirect + '\',\'' + _target + '\',\'' + _meth + '\',\'' + _is_fix + '\',\'' + _width + '\',\'' + _is_iframe + '\')">Yes</button>' +
                       '<button class="btn medium btn-danger btn-sm" onclick="close_box()">No</button>';
            c_str_ = '</div>';

            $(_data).validation();
            if (!$(_data).validate()) {
            } else {
                return_modalbox(o_str_ + _message_ + c_str_ + f_str, '', '400px');
            }
        });

        $('html').on('click', '[crud-name=expand-search]', function (e) {
            if ($('html').find('.x-block-full').size() > 0) {
                $('.x-block.small').addClass("col-md-3").show();
                $('.x-block-full').addClass('big').addClass("col-md-9").removeClass('x-block-full').show();
            } else {
                $('.x-block.small').hide();
                $('.x-block.big').addClass('x-block-full').removeClass('big').removeClass("col-md-9").show();
            }
        });
        is_search = false;
        $('html').on('keyup', '[crud-search="true"]', function (e) {
            var $this = $(this),
                    _val = $this.val(),
                    _name = $this.attr('name'),
                    _act_url = $this.attr('search-url'),
                    _act_target = $this.attr('search-target');
            if (is_search === false) {
                (e.keyCode) ? key = e.keyCode : key = e.which;
                switch (key) {
                    case 40:
                        $('.modal-content, body').find('tr[tabindex]').eq(1).focus().css({
                            'background': 'rgb(228, 250, 228)'
                        });
                        break;
                    default:
                        var inUrl = _act_url + '&' + $('form#crud-data').serialize();
                        $.ajax({
                            beforeSend: function () {
                                is_search = true;
                                $('span.x-small-loading').html(animate_small);
                            },
                            type: "POST",
                            url: inUrl,
                            data: _name + '=' + _val,
                            success: function (result) {
                                setTimeout(function () {
                                    $('span.x-small-loading').html('');
                                }, 1000);
                                $(_act_target).html(result);
                                is_search = false;
                            },
                            dataType: "html"
                        });
                        break;
                }

            }
        });
    });
}(window.$);


(function ($) {
    $.widget("ui.combobox", {
        _create: function () {
            var self = this;
            var select = this.element,
                    theWidth = select.width(),
                    selected = select.children(":selected"),
                    theTitle = (select.attr("placeholder")) ? select.attr("placeholder").replace(/\-/g, ' ') : '-select-',
                    tabIndex = (select.attr("tabindex")) ? select.attr("tabindex") : '',
                    readOnly = (select.attr("readonly")) ? select.attr("readonly") : '',
                    value = selected.val() ? selected.text() : "";
            select.hide();
            var input = $("<input>");
            if (tabIndex !== '') {
                input.attr('tabindex', tabIndex);
            }
            if (readOnly !== '') {
                input.attr('readonly', readOnly);
            }

            input.val(value)
                    .attr('placeholder', '' + theTitle + '')
                    .autocomplete({
                        delay: 0,
                        minLength: 0,
                        source: function (request, response) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response(select.children("option").map(function () {
                                var text = $(this).text();
                                if (this.value && (!request.term || matcher.test(text)))
                                    return {
                                        label: text.replace(
                                                new RegExp(
                                                        "(?![^&;]+;)(?!<[^<>]*)(" +
                                                        $.ui.autocomplete.escapeRegex(request.term) +
                                                        ")(?![^<>]*>)(?![^&;]+;)", "gi"
                                                        ), "$1"),
                                        value: text,
                                        option: this
                                    };
                            }));
                        },
                        select: function (event, ui) {
                            ui.item.option.selected = true;
                            //select.val( ui.item.option.value );
                            self._trigger("selected", event, {
                                item: ui.item.option
                            });
                        },
                        change: function (event, ui) {
                            if (!ui.item) {
                                var matcher = new RegExp("^" + $.ui.autocomplete.escapeRegex($(this).val()) + "$", "i"),
                                        valid = false;
                                select.children("option").each(function () {
                                    if (this.value.match(matcher)) {
                                        this.selected = valid = true;
                                        return false;
                                    }
                                });
                                if (!valid) {
                                    // remove invalid value, as it didn't match anything
                                    $(this).val("");
                                    select.val("");
                                    return false;
                                }
                            }
                        }
                    })
                    .addClass("ui-widget ui-widget-content ui-corner-left");
            var span = $("<span style=\" white-space: nowrap;\" class='custom-combobox'></span>")
                    .append(input).insertAfter(select);


            $("<a>")
                    .attr("tabIndex", -1)
                    .css({ 'background': '#2693ba' })
                    .attr("title", "Show All Items")
                    .insertAfter(input)
                    .button({
                        icons: {
                            primary: "ui-icon-triangle-1-s"
                        },
                        text: false
                    }).html('<i class="fa fa-angle-down"></i>')
                    .removeClass("ui-corner-all")
                    .addClass("custom-combobox-toggle ui-corner-right")
                    .click(function () {
                        // close if already visible
                        if (input.autocomplete("widget").is(":visible")) {
                            input.autocomplete("close");
                            return;
                        }

                        // pass empty string as value to search for, displaying all results
                        input.autocomplete("search", "");
                        input.focus();
                    });
        }
    });
})(jQuery);

// optimus
function _load(_url, _is_close_box, _url_push, _target, is_fix, _width, _is_iframe, _meth) {
    $.ajax({
        dataType: 'html',
        type: 'GET',
        beforeSend: function () {
            if (_meth === undefined) {
                loading();
            }
        },
        url: _url.replace('#!', ''),
        success: function (result) {
            if (_meth === undefined) {
                close_loading_box(_is_close_box);
            }
            if (_url_push !== undefined) {
                if (_url_push !== 'false') {
                    if (window.history.pushState) {
                        if (typeof (window.history.pushState) === 'function') {
                            window.history.pushState(null, null, _url);
                        } else {
                            window.location.hash = '#!' + path;
                        }
                    }
                }
            }
            if (_meth !== undefined) {
                switch (_meth) {
                    case 'prepend':
                        $(_target).prepend(result);
                        break;
                    case 'append':
                        $(_target).append(result);
                        break;
                    default:
                        $(_target).html(result);
                        break;
                }
            } else {
                _result_convert(_target, result, is_fix, _width, _is_iframe);
            }
        }
    });
}
function _post(_isSocket, _data, _is_close_box, _url, _url_push, _url_redirect, _target, _meth, _is_fix, _width, _is_iframe) {
    $.ajax({
        type: 'POST',
        beforeSend: function () {
            if (_is_close_box !== 'false') {
                loading();
            } else {
                $('#fadingBarsG').remove();
                $(_target).html(animate_small)
            }
        },
        url: _url.replace('#!', ''),
        data: $(_data).serialize(),
        success: function (result) {
            if (_isSocket == 'true') {
                var rs_ = JSON.parse(result);
                if (typeof rs_.controller !== 'undefined') {
                    wsSend(result);
                    if (_is_close_box !== 'false') {
                        if (_target !== 'modalbody') {
                            close_box();
                        }
                    }
                }
            } else if (_url_redirect !== undefined) {
                _load(_url_redirect, _is_close_box, _url_push, _target, _is_fix, _width);
                //reset_form();
                if (_is_close_box !== 'false') {
                    if (_target !== 'modalbody') {
                        close_box();
                    }
                    notive('Data was submited');
                }
            } else {
                if (_meth !== undefined) {
                    switch (_meth) {
                        case 'prepend':
                            $(_target).prepend(result);
                            break;
                        case 'append':
                            $(_target).append(result);
                            break;
                        default:
                            $(_target).html(result);
                            break;
                    }
                    reset_form();
                } else {
                    _result_convert(_target, result, _is_fix, _width, _is_iframe);
                }
                if (_is_close_box !== 'false') {
                    close_box();
                }
            }

        }
    });
}
function _confirm_post(t, _isSocket, _data, _is_close_box, _url, _url_push, _url_redirect, _target, _meth, _is_fix, _width, _is_iframe) {
    $.ajax({
        type: 'POST',
        beforeSend: function () {
            if (_is_close_box !== 'false') {
                loading();
            } else {
                $('#fadingBarsG').remove();
                $(_target).html(animate_small)
            }
            $(t).html('Loading...');
        },
        url: _url.replace('#!', ''),
        data: $(_data).serialize(),
        success: function (result) {
            if (_isSocket == 'true') {
                var rs_ = JSON.parse(result);
                if (typeof rs_.controller !== 'undefined') {
                    wsSend(result);
                }
                form_reset(_data);
            }
            if (_url_redirect !== undefined) {
                _load(_url_redirect, _is_close_box, _url_push, _target, _is_fix, _width);
                //reset_form();
                if (_is_close_box !== 'false') {
                    if (_target !== 'modalbody') {
                        close_box();
                    }
                    notive('Data was submited');
                }
                close_box();
            } else {
                if (_meth !== undefined) {
                    switch (_meth) {
                        case 'prepend':
                            $(_target).prepend(result);
                            break;
                        case 'append':
                            $(_target).append(result);
                            break;
                        default:
                            $(_target).html(result);
                            break;
                    }
                    reset_form();
                } else {
                    _result_convert(_target, result, _is_fix, _width, _is_iframe);
                }
                if (_is_close_box !== 'false') {
                    close_box();
                }
            }

        }
    });
}
function _method(_isSocket, _type, _url, _target, _is_close_box, _url_push, _data, _url_redirect, _meth, _is_fix, _width, _is_iframe) {
    switch (_type) {
        case 'GET':
            $.ajax({
                type: 'GET',
                beforeSend: function () {
                    loading();
                },
                url: _url.replace('#!', ''),
                data: $(_data).serialize(),
                success: function (result) {
                    if (_isSocket == 'true') {
                        var rs_ = JSON.parse(result);
                        if (typeof rs_.controller !== 'undefined') {
                            wsSend(result);
                        }
                        form_reset(_data);
                    }
                    if (_url_redirect !== undefined) {
                        _load(_url_redirect, _is_close_box, _url_push, _target, _is_fix, _width, _is_iframe);
                        reset_form();
                    } else {
                        _result_convert(_target, result, _is_fix, _width, _is_iframe);
                    }
                    notive('Data Berhasil Disubmit');
                }
            });
            break;
        case 'POST':
            $(_data).validation();
            if (!$(_data).validate()) {
            } else {
                _post(_isSocket, _data, _is_close_box, _url, _url_push, _url_redirect, _target, _meth, _is_fix, _width, _is_iframe);
            }
            break;
        default:
            _load(_url, _is_close_box, _url_push, _target, _is_fix, _width, _is_iframe, _meth);
            if (_url_redirect !== undefined) {
                var n = _url.indexOf("MoveAccount");
                if (n > 1) {
                    close_box();
                    loading();
                    setTimeout(function () {
                        _load(_url_redirect, _is_close_box, _url_push, _target, _is_fix, _width, _is_iframe);
                    }, 1000);
                } else {
                    _load(_url_redirect, _is_close_box, _url_push, _target, _is_fix, _width, _is_iframe);
                }
            }
            break;
    }
}
!function ($) {
    $(function () {
        $('html').on("keydown", function (e) {
            (e.keyCode) ? key = e.keyCode : key = e.which;
            if (key === 83 && e.ctrlKey) {
                $('body').find('[accesskey="ctrl+s"]').click();
                e.preventDefault();
            }
            if (key === 73 && e.ctrlKey) {
                $('body').find('[accesskey="ctrl+i"]').click();
                e.preventDefault();
            }
            if (key === 68 && e.ctrlKey) {
                $('body').find('[accesskey="ctrl+d"]').click();
                e.preventDefault();
            }
            if (key === 85 && e.ctrlKey) {
                $('body').find('[accesskey="ctrl+u"]').click();
                e.preventDefault();
            }
            if (key === 8 && e.ctrlKey) {
                $('body').find('[accesskey="ctrl+backspace"]').click();
                e.preventDefault();
            }
            if (key === 70 && e.ctrlKey) {
                $('body').find('[accesskey="ctrl+f"]').click();
                e.preventDefault();
            }
            if ((key === 116 && e.ctrlKey) || key === 116) {
                $('body').find('[accesskey="ctrl+f5"]').click();
                e.preventDefault();
            }

        });
    });
}(window.$);
// combobox 
!function ($) {
    $(function () {
        $('html').on('click', '[ajax=true]', function (e) {
            $this = $(this)
                    , _type = $this.attr('ajax-type')
                    , _url = ($this.attr('ajax-url')) ? $this.attr('ajax-url') : $this.attr('href')
                    , _target = $this.attr('ajax-target')
                    , _meth = ($this.attr('ajax-method')) ? $this.attr('ajax-method') : undefined
                    , _data = $this.attr('ajax-data')
                    , _is_close_box = ($this.attr('is_close_box')) ? $this.attr('is_close_box') : 'false'
                    , _url_redirect = $this.attr('ajax-redirect')
                    , _is_iframe = ($this.attr('ajax-iframe')) ? $this.attr('ajax-iframe') : 'false'
                    , ajax_title = ($this.attr('ajax-title')) ? $this.attr('ajax-title') : $('html').find('title').html()
                    , _url_push = $this.attr('url-push')
                    , _is_fix = ($this.attr('modal-fix')) ? $this.attr('modal-fix') : 'true'
                    , _isSocket = ($this.attr('socket')) ? $this.attr('socket') : 'false'
                    , _width = ($this.attr('modal-width')) ? $this.attr('modal-width') : '50%';

            e.preventDefault();
            if (_is_close_box === 'true') {
                close_box();
            }
            _method(_isSocket, _type, _url, _target, _is_close_box, _url_push, _data, _url_redirect, _meth, _is_fix, _width, _is_iframe);

            document.title = ajax_title;
        });


    });
}(window.$);
function close_box(iframe) {
    if (iframe === 'iframe') {
        parent = $("html#xamzo", window.parent.document);
        parent.find('body, #wrapper').css({
            opacity: '1'
        });
        parent.find('.modal').remove();
    } else {
        $(".modal-box").remove();
        $('.modal').remove();
        $(wrapper_ + ', body, #in-cms, #wrapper').css({
            opacity: 1
        });
    }
    uf = $('input[name="userfile[]"]');
    for (i = 0; i < uf.size() ; i++) {
        if (i > 1) {
            uf[i].remove();
        }
    }
}

function close_loading_box(_is_close_box, iframe) {
    if (_is_close_box === 'true') {
        $(wrapper_ + ', body').css({
            opacity: '1'
        });
    }
    if (iframe === 'iframe') {
        parent = $("html#xamzo", window.parent.document);
        if (_is_close_box === 'true') {
            parent.find('body').css({
                opacity: '1'
            });
        }
        parent.find('.x-loading-box').remove();
    } else {
        $(".x-loading-box").remove();
        if (_is_close_box === 'true') {
            $(wrapper_ + ', body').css({
                opacity: '1'
            });
        }
    }
    uf = $('input[name="userfile[]"]');
    for (i = 0; i < uf.size() ; i++) {
        if (i > 1) {
            uf[i].remove();
        }
    }
}

function getParameterByName(name, url) {
    if (!url)
        url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
    if (!results)
        return null;
    if (!results[2])
        return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function _url_craw() {
    b = window.document.location.hash;
    patern = "^(#!)";
    c = new RegExp(patern);
    if (b.indexOf('DistinguishedName') != -1) {
        _load('#!/ActiveDirectory/List/?type=' + getParameterByName('type'), 'true', '', wrapper_);
        if (wrapper_ != "#result-search") {
            if (getParameterByName('DistinguishedName') != "") {
                _load(window.document.location.hash, 'true', '', '#result-search');
            }
        }

    } else {
        if (b.match(c)) {
            close_box();
            _load(b, 'true', '', wrapper_);
        }
    }

}
window.addEventListener("hashchange", _url_craw, false);
$(document).ready(function () {
    _url_craw();
});
$(document).keyup(function (e) {
    e.preventDefault();
    if (e.keyCode === 27) {
        close_box('iframe');
        close_box();
        $('.x-autocomplete').html('');
    }
});
//collaps

!function ($) {
    $(function () {
        _par = $('.collapse');
        $.each(_par, function () {
            $(this).find('div.coll-child').hide().first().show();
        });
        $('html').on('click', '.coll-menu', function (e) {
            $this = $(this)
                    , _parent = ($this.parent()) ? $this.parent() : '0'
                    , _speed = (_parent.attr('coll-speed')) ? _parent.attr('coll-speed') : 'fast'
                    , _target = ($this.attr('coll-target')) ? $this.attr('coll-target') : '0';
            if ($this.hasClass('active-coll-menu')) {

            } else {
                $(_parent).find('.coll-menu').removeClass('active-coll-menu');
                $this.addClass('active-coll-menu');
                $(_parent).find('.coll-child').hide(_speed).removeClass('active-coll-content');
                $(_parent).find(_target).slideDown(_speed).addClass('active-coll-content');
            }
        });
    });
}(window.$);
//core

$(function () {
    $.ajaxSetup({
        traditional: true,
        error: function (jqXHR, exception) {
            var title = "Error";
            var message ="";
            if (jqXHR.status === 0) {
                title = "Session Timeout";
                message = "Your session is time out!";
            } else if (jqXHR.status === 404) {
                message = "Requested page not found. [404]"; 
            } else if (jqXHR.status === 500) {
                message = "Internal Server Error [500]"; 
            } else if (exception === 'parsererror') {
                message = "Requested JSON parse failed."; 
            } else if (exception === 'timeout') {
                message = "Time out error."; 
            } else if (exception === 'abort') {
                message = "Ajax request aborted.";
            } else {
                message = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            var fMessage = '<div class="modal-header header-color">' +
                    '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                    '<h4 class="modal-title">' + title + '</h4>' +
                    '</div>' +
                    '<div class="modal-body"><p>' + message + '</p></div>';
            return_modalbox(fMessage, 'true', '300px');
            if (jqXHR.status === 0) {
                location.reload(true);
            } 
        }
    });
});
function before_loading(_target) {
    $(_target).removeClass(animate_).css({
        opacity: 1
    });
    $('.pop-content').parent().remove();
    loading();
}
function reset_form() {
    $('form input, form textarea').val('');
    $('[contenteditable], .x-tag span.pTag').html('');
}
function loading(a) {
    $(".x-loading-box").remove();
    cmd = "<div class='modal-box x-loading-box' style='display:none;border:none;padding:0px; z-index:1000;'>" + loading_ + "</div>";
    $(wrapper_).css({
        opacity: 0.3
    });
    $('html').append(cmd);
    function _make_loading() {
        b = $(window).height(), c = $(".modal-box").height(), d = (b - c) / 2, e = $(window).width(), f = (e - $(".modal-box").width()) / 2;
        $(".modal-box").css({
            position: 'fixed',
            left: f,
            top: d
        }).fadeIn('slow');
    }
    _make_loading();
}

function notive(text) {
    $(".modal-box").remove();
    cmd = "<div class='modal-box' onclick='$(this).remove();close_box()' style='padding:0px; z-index:1000;'>" + "<div class='modal-content' style='background: #fff;font-size:14px;padding:10px; text-align:center; cursor:pointer;' align='center'>" + text + "</div>" + "</div>";
    $('html').append(cmd);
    function _make_notive() {
        c = $(".modal-box").height(), d = ('40%'), e = $(window).width(), f = (e - $(".modal-box").width()) / 2;
        $(".modal-box").css({
            position: 'fixed',
            left: f,
            top: d
        });
    }
    _make_notive();
    setTimeout(function () {
        $(".modal, .modal-box").remove();
        close_box();
    }, 5000);
}

function _result_convert(_target, result, is_fix, _width, _is_iframe) {
    if (_target != 'modalbody' && _target != 'modalbox') {
        $('#full-awesomesearch').hide();
    }
    if (_target === 'modalbody') {
        return_bodybox(result, is_fix, _width, _is_iframe);
    }
    if (_target === 'modalbox') {
        return_modalbox(result, is_fix, _width, _is_iframe);
    } else {

        $(_target).html(result).addClass(animate_).addClass("animated").css({
            opacity: 1
        });
        is_box = $(_target).parent().parent().parent().find('.modal').size();
        if (is_box === 0) {
        }
    }
    $('html').find('div#ui-datepicker-div').removeClass('ui-helper-hidden-accessible');
    $('[data-toggle="tooltip"]').tooltip();
}
function return_modalbox(content, is_fix, _width, _is_iframe) {
    close_box();
    var el = '';
    if (_is_iframe === 'true') {
        el = $("html#xamzo", window.parent.document);
    } else {
        el = $("html#xamzo");
    }
    el.append('<div class="modal">&nbsp;</div>');
    if ($(window).width() <= 320) {
        width_ = '90%';
    } else {
        if (_width == '100%') {
            width_ = ($(window).width() - 50) + 'px';
        } else {
            width_ = _width;
        }
    }
    el.find(".modal").append('<div class="modal-box" style="width:' + width_ + '">' + "<div class='modal-content'></div>" + "</div>");
    el.find(".modal-content").append(content);
    if (_width == '100%') {
        el.find(".modal-content").height(($(window).height() - 30) + 'px')
    }
    function _make_modalbox() {
        b = el.width();
        c = (b - el.find(".modal-box").width()) / 2;
        d = screen.height;
        if (_width == '100%') {
            e = '10px';
        } else {
            e = (d - el.find(".modal-box").height()) / 3;
        }

        if (is_fix !== 'false') {
            el.find(".modal-box").css({
                'position': 'fixed',
                left: c,
                top: e
            });
        } else {
            var xe = '100px';
            el.find(".modal-box").css({
                'position': 'absolute',
                left: c,
                top: xe
            });
        }
    }
    _make_modalbox();
    el.find(".loading").html("");
    el.find('.modal').css({
        'height': $('body').height(),
        'min-height': '100%'
    });
    if (_is_iframe === 'true') {
        el.find('.modal').css({
            'top': '10px'
        });
        el.find(".modal-box").css({
            'position': 'absolute'
        });
    }
    el.find('body').css({
        opacity: .1
    });
    el.find('.modal').show();
    $('body').scrollTop(0);
    $('[data-toggle="tooltip"]').tooltip();
}

function return_bodybox(content, is_fix, _width, _is_iframe) {
    close_box();
    var el = '';
    if (_is_iframe === 'true') {
        el = $("body", window.parent.document);
    } else {
        el = $("body");
    }
    el.append('<div class="modal">&nbsp;</div>');
    if ($(window).width() <= 320) {
        width_ = '90%';
    } else {
        width_ = _width;
    }
    el.find(".modal").append('<div class="modal-box" style="width:' + width_ + '">' + "<div class='modal-content'></div>" + "</div>");
    el.find(".modal-content").append(content);
    function _make_modalbox() {
        b = el.width();
        c = (b - el.find(".modal-box").width()) / 2;
        d = screen.height;
        e = (d - el.find(".modal-box").height()) / 3;
        if (is_fix !== 'false') {
            el.find(".modal-box").css({
                'position': 'fixed',
                left: c,
                top: 80
            });
        } else {
            el.find(".modal-box").css({
                'position': 'absolute',
                left: c,
                top: 80
            });
        }
    }
    _make_modalbox();
    el.find(".loading").html("");
    el.find('.modal').css({
        'height': $('body').height(),
        'min-height': '100%'
    });
    if (_is_iframe === 'true') {
        el.find('.modal').css({
            'top': '10px'
        });
        el.find(".modal-box").css({
            'position': 'absolute'
        });
    }
    el.find('#wrapper').css({
        opacity: .1
    });
    el.find('.modal').show();
    $('body').scrollTop(0);
    $('[data-toggle="tooltip"]').tooltip();
}

!function ($) {
    $(function () {
        _par = $('[modal="true"]');
        $.each(_par, function () {
            $('#' + $(this).attr('modal-target')).hide();
        });
        $('html').on('click', '[modal="true"]', function (e) {
            $this = $(this), _id = new Date(), _target = $('#' + $this.attr('modal-target'))
                    , _is_fix = ($this.attr('modal-fix')) ? $this.attr('modal-fix') : 'true'
                    , _width = ($this.attr('modal-width')) ? $this.attr('modal-width') : '50%'
                    , _content = _target.html();
            close_box();
            return_modalbox(_content, _is_fix, _width);
        });
    });
}(window.$);
/*Auto Complete*/

!function ($) {
    $(function () {
        $('html').on('keydown', '[data-type="autocomplete"]', function (e) {
            (e.keyCode) ? key = e.keyCode : key = e.which;
            var $this = $(this);
            var x = $this.parent().find('.x-autocomplete');
            switch (key) {
                case 37:
                case 38:
                    idx = $(this).attr('tabindex');
                    $('body').find('[tabindex]').eq(parseInt(idx) + 1).focus().css({
                        'background': 'rgb(228, 250, 228)'
                    });
                    break;
                case 39:
                case 40:
                    x.find('[tabindex]').eq(0).focus().css({
                        'background': 'rgb(228, 250, 228)'
                    });
                    break;
                default:
                    var _url = ($this.attr('auto-url')) ? $this.attr('auto-url') : '#',
                            _name = ($this.attr('data-name')) ? $this.attr('data-name') : $this.attr('name');
                    _autocomplete($this, _url, _name);
                    break;
            }
        });
    });
}(window.$);
function _autocomplete(i, uri, name) {
    var parent = i.parent();

    parent.css({
        'position': 'relative'
    });
    var x = parent.find('.x-autocomplete');

    if (x.length > 1) {
        x.remove();
    }
    parent.append('<div class="x-autocomplete"></div>');
    var xhr = $.ajax({
        beforeSend: function () {
            $('#fadingBarsG').remove();
            x.html(animate_small);
        },
        type: 'POST',
        url: base_ + uri,
        data: name + '=' + i.val(),
        success: function (rs) {
            x.html(rs);
            keyK(x);
            x.find('li, tr').click(function () {
                x.html('');
            });
        }
    });


}

function keyK(x) {
    var col = 1;
    var t = x.find('li, tr');
    t.on("keydown", function (e) {
        var current = $('.x-autocomplete').attr('tabindex');
        (e.keyCode) ? key = e.keyCode : key = e.which;
        switch (key) {
            case 37:
                next = current - 1;
                break;
                //left
            case 38:
                next = current - col;
                break;
                //up             
            case 39:
                next = current + 1;
                break; 	//right
            case 40:
                next = current + col;
                break; 	//down
        }


        function cursor(x) {
            var m = x.find('li[tabindex="' + next + '"] a');
            if (m.length > 0) {
                m.focus().css({
                    'background': 'rgb(228, 250, 228)'
                });
            } else {
                x.find('li[tabindex="' + next + '"], tr[tabindex="' + next + '"]').focus().css({
                    'background': 'rgb(228, 250, 228)'
                }).on('keydown', function (e) {
                    (e.keyCode) ? key = e.keyCode : key = e.which;
                    if (key === 13) {
                        $(this).click();
                        $(this).click(function () {
                            x.html('');
                        });
                        $(x).parent().find('input').focus();
                    }
                });
            }
        }

        if (key === 37 | key === 38 | key === 39 | key === 40) {
            t.removeAttr('style').find('a').removeAttr('style');
            if (typeof attr !== 'undefined' && attr !== false) {
                if (key === 37 | key === 39) {
                    cursor(x);
                }
            } else {
                cursor(x);
            }
            current = next - 1;
        }

    });
}

function _sort_asc(sort, uri, dest) {
    $.ajax({
        type: 'POST',
        url: base_ + uri,
        data: 'order=' + sort + '&by=ASC' + '&search=' + $('#x-head-action input[name="search"]').val(),
        success: function (rs) {
            $(dest).html(rs);
        }
    });
}
function _sort_desc(sort, uri, dest) {
    $.ajax({
        type: 'POST',
        url: base_ + uri, data: 'order=' + sort + '&by=DESC' + '&search=' + $('#x-head-action input[name="search"]').val(),
        success: function (rs) {
            $(dest).html(rs);
        }
    });
}
function form_reset(id) {
    $(id + ' input[type="text"]:not([readonly]), ' + id + ' input[type="password"]:not([readonly]), ' + id + ' input[type="radio"], ' + id + ' input[type="checkbox"], ' + id + ' textarea:not([readonly]), ' + id + 'select:not([readonly])').val('');
    $(id + ' span.x-errorlist').remove();
}
function close_search() {
    $('.in-s-content').remove();
    $('input[name="search"]').val('');
}

function popupwindow(url, title, w, h) {
    wLeft = parent.window.screenLeft ? parent.window.screenLeft : parent.window.screenX;
    wTop = parent.window.screenTop ? parent.window.screenTop : parent.window.screenY;
    var left = wLeft + (parent.window.innerWidth / 2) - (w / 2);
    var top = wTop + (parent.window.innerHeight / 2) - (h / 2);
    return parent.window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + 980 + ', height=' + h + ', top=' + top + ', left=' + left);
}


function x_search_dd(i) {
    if ($(i).val() !== '') {
        $(i).parent().parent().find("a:not('" + $(i).val().toLowerCase() + "')").hide().focus();
        $(i).parent().parent().find("a:contains('" + $(i).val().toLowerCase() + "')").show().focus();
        $(i).focus();
    } else {
        $(i).parent().parent().find("a").show();
    }
}
function x_table_search(i) {
    if ($(i).val() !== '') {
        $(i).parent().parent().find("td span.s-parameter:not('" + $(i).val().toLowerCase() + "')").parent().parent().hide().focus();
        $(i).parent().parent().find("td span.s-parameter:contains('" + $(i).val().toLowerCase() + "')").parent().parent().show().focus();
        $(i).focus();
    } else {
        $(i).parent().parent().find("td span.s-parameter").parent().parent().show();
    }
}
function x_list_search(i) {
    if ($(i).val() !== '') {
        $(i).parent().parent().parent().find(".list-search span.s-parameter:not('" + $(i).val().toLowerCase() + "')").parent().hide().focus();
        $(i).parent().parent().parent().find(".list-search span.s-parameter:contains('" + $(i).val().toLowerCase() + "')").parent().show().focus();
        $(i).focus();
    } else {
        $(i).parent().parent().parent().find(".list-search span.s-parameter").parent().show();
    }
}
function x_search_show(i) {
    var st = $(i).attr('active');
    if (st === 'false') {
        $('.x-setting-search').slideDown();
        $(i).attr('active', 'true');
    } else {
        $('.x-setting-search').slideUp();
        $(i).attr('active', 'false');
    }
}
function x_set_list_active(i) {
    $(i).parent().parent().find('a').removeClass('active');
    $(i).addClass('active');
}

function get_child(cls) {
    if ($('table').find('tr.' + cls).hasClass('active')) {
        $('table').find('tr.' + cls).removeClass('active').hide();
    } else {
        $('table').find('tr.' + cls).addClass('active').show();
    }

}

function get_detail(id) {
    if ($(id).hasClass('active')) {
        $(id).removeClass('active').show();
    } else {
        $(id).addClass('active').hide();
    }
}

function load(url, id) {
    $.ajax({
        beforeSend: function () {
            loading();
        },
        url: base_ + url,
        success: function (rs) {
            $(id).html(rs);
            close_box();
        }
    });
}

var wordCounts = {};

$(document).ready(function () {
    console.log('You like to look under the hood? Why not help us build the engine? http://xamzo.com/');
});

function modal_table_focus() {
    $('.modal-content').find('tr[tabindex]').eq(1).focus().css({
        'background': 'rgb(228, 250, 228)'
    });
    $('.modal-content').on("keydown", function (e) {
        col = 1;

        var current = $('.modal-content').find('tr[tabindex]:focus').attr('tabindex');
        (e.keyCode) ? key = e.keyCode : key = e.which;
        switch (key) {
            case 37:
                next = current - 1;
                break; 		//left
            case 38:
                next = current - col;
                break; 	 //up            
            case 39:
                next = (1 * current) + 1;
                break; 	//right
            case 40:
                next = (1 * current) + col;
                break; 	//down
            default:

                break;

        }
        if (key === 37 | key === 38 | key === 39 | key === 40) {
            $('.modal-content').find('tr[tabindex]').css({
                'background': 'transparent'
            });
            $('.modal-content').find('tr[tabindex="' + next + '"]').focus().css({
                'background': 'rgb(228, 250, 228)'
            }).on('keydown', function (e) {
                (e.keyCode) ? key = e.keyCode : key = e.which;
                if (key === 13) {
                    var ini = $(this).click();
                }
            });

            current = next;
        }

    });
}

function table_focus() {
    $('body').find('tr[tabindex]').eq(0).focus().css({
        'background': 'rgb(228, 250, 228)'
    });
    $('body').on("keydown", function (e) {
        col = 1;
        var current = $('body').find('tr[tabindex]:focus').attr('tabindex');
        (e.keyCode) ? key = e.keyCode : key = e.which;
        switch (key) {
            case 37:
                next = current - 1;
                break; 		//left
            case 38:
                next = current - col;
                break; 	 //up            
            case 39:
                next = (1 * current) + 1;
                break; 	//right
            case 40:
                next = (1 * current) + col;
                break; 	//down
            default:

                break;

        }
        if (key === 37 | key === 38 | key === 39 | key === 40) {
            if ($('body').find('tr[tabindex]').find('input[type="checkbox"]').length > 0) {
                var listX = $('body').find('tr[tabindex]').find('input:not(:checked)');
                listX.parent().parent().parent().css({
                    'background': 'transparent'
                });
                var listC = $('body').find('tr[tabindex]').find('input[type="checkbox"]:checked');
                listC.parent().parent().parent().css({
                    'background': '#fffccc'
                });
            } else {
                $('body').find('tr[tabindex]').css({
                    'background': 'transparent'
                });
            }
            $('body').find('tr[tabindex="' + next + '"]').focus().css({
                'background': 'rgb(228, 250, 228)'
            }).on('keydown', function (e) {
                (e.keyCode) ? key = e.keyCode : key = e.which;
                if (key === 13) {
                    $(this).click();
                }
            });
            current = next;
        }

    });
}

function showTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    // add a zero in front of numbers<10
    h = checkTime(h);
    m = checkTime(m);
    s = checkTime(s);
    $(".clock").text(h + ":" + m + ":" + s);
    t = setTimeout('showTime()', 1000);
}
function checkTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}
showTime();
$(document).ready(function () {
    table_focus();

});
setInterval(function () {
    $('.custom-combobox input').keyup(function (e) {
        e.preventDefault();
        if (e.keyCode === 27) {
            $(this).val('');
        }
    });
}, 100);

function file_delete(src) {
    $.ajax({
        type: "POST",
        url: base_ + "Media/Delete",
        data: "src=" + src,
        success: function (rs) {
            return_modalbox(rs, "true", "400px");
        }
    });
}

function file_url(src) {
    $.ajax({
        type: "POST",
        url: base_ + "Media/Details",
        data: "src=" + src,
        success: function (rs) {
            return_modalbox(rs, "true", "400px");
        }
    });
}

function this_file_delete(src) {
    $.ajax({
        type: "POST",
        url: base_ + "Media/DoDelete",
        data: "src=" + src,
        success: function (rs) {
            $("[src='" + src + "'], [dir='" + src + "'], [src='~" + src + "'], [dir='~" + src + "']").parent().parent().remove();
            close_box();
        }
    });
    return false;
}


var animate_small =
        '<div class="sk-spinner sk-spinner-circle">' +
        '<div class="sk-circle1 sk-circle"></div>' +
        '<div class="sk-circle2 sk-circle"></div>' +
        '<div class="sk-circle3 sk-circle"></div>' +
        '<div class="sk-circle4 sk-circle"></div>' +
        '<div class="sk-circle5 sk-circle"></div>' +
        '<div class="sk-circle6 sk-circle"></div>' +
        '<div class="sk-circle7 sk-circle"></div>' +
        '<div class="sk-circle8 sk-circle"></div>' +
        '<div class="sk-circle9 sk-circle"></div>' +
        '<div class="sk-circle10 sk-circle"></div>' +
        '<div class="sk-circle11 sk-circle"></div>' +
        '<div class="sk-circle12 sk-circle"></div>' +
    '</div>';


!function ($) {
    $(function () {
        _par = $('.tab');
        $.each(_par, function () {
            $($(this).attr('tab-parent')).find('.child-tab').hide().first().show();
        });
        $('html').on('click', '.tab a', function (e) {
            $this = $(this)
                    , _parent = ($this.parent().attr('tab-parent')) ? $this.parent().attr('tab-parent') : '0'
                    , _target = ($this.attr('tab-target')) ? $this.attr('tab-target') : '0'
                    , _animation = ($this.parent().attr('tab-animation')) ? $this.parent().attr('tab-animation') : 'none';
            $this.parent().find('a').removeClass('active');
            $this.addClass('active');
            $(_parent + ' .child-tab').removeClass(_animation).removeClass('active').hide().addClass("animated");
            $(_parent + ' ' + _target).addClass(_animation).addClass('active').show().addClass("animated");
            e.preventDefault();
        });
    });
}(window.$);


function connetionState() {
    if (typeof socket !== 'undefined') {
        if (socket.connected === true) {
            return true;
        } else {
            return false;
        }
    }
}
setInterval(function () {
    if (connetionState()) {
        var sHtml = parseInt($('html').attr('state'));
        $('body').find('.connection-off').remove();
        $('body').css({
            'overflow': 'auto'
        });
    } else {
        $('body').css({
            'overflow': 'hidden'
        });
        $('body').find('.connection-off').remove();
        var _xbody = '<div class="connection-off"><div class="state">&nbsp;</div><div class="p"><h3>Disconnected</h3><p>We are trying to reset connect in <span class="intimer"></span> seconds. See what happen <a href="javascript:void(0)" onclick="showWhat()">here</a><p></div></div>';
        $('body').append(_xbody);
        timerBack();
        $('html').attr('state', '0');
    }
}, 1000);

function showWhat() {
    o_str_ = '<div class="modal-header header-color">' + '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' + '<h4 class="modal-title">Disconnected</h4>' + '</div>' + '<div class="modal-body">';
    c_str_ = '</div>';
    return_modalbox(o_str_ + '<p style="text-align:justify">This happen, because you are not connected to the Internet or because our server temporarily experiencing problems. While disconnected, you can continue to use <b> IDSync+</b>, but the changes you make will not be saved.</p> <p style="text-align:justify">Once you reconnect to the server, all changes that have been made will be saved and everything will be fine, but if your browser crashes, you will lose your changes before</p>' + c_str_, 'false', '400px');
}
function timerBack() {
    var t = 10;
    setInterval(function () {
        if (t > 0) {
            t = t - 1;
        } else {
            t = 10;
        }
        $('span.intimer').html(t);
    }, 1000);
}

$(document).ready(function () {
    setInterval(function () {
        jQuery("time.timeago").timeago();
    }, 3000);
})

// sharepoint
function sp_file_delete(id, src) {
    $.ajax({
        type: "POST",
        url: base_ + "Media/SPDelete",
        data: "id=" + id + "&src=" + src,
        success: function (rs) {
            return_modalbox(rs, "true", "400px");
        }
    });
}

function sp_file_url(src) {
    $.ajax({
        type: "POST",
        url: base_ + "Media/Details",
        data: "src=" + src,
        success: function (rs) {
            return_modalbox(rs, "true", "400px");
        }
    });
}

function sp_edit_url(id, title) {
    $.ajax({
        type: "POST",
        url: base_ + "Media/SPEdit",
        data: "id=" + id + "&title=" + title,
        success: function (rs) {
            return_modalbox(rs, "true", "400px");
        }
    });
}

function sp_this_file_edit(id) {
    var new_name = $(".modal form#x-modal").find("input[name='sp_title']").val();
    $.ajax({
        type: "POST",
        url: base_ + "Media/DoSPEdit",
        data: "id=" + id + "&" + $(".modal form#x-modal").serialize(),
        success: function (rs) {
            $('#sp-name-' + id).val(rs);
            $('#sp-info-' + id).html(rs);
            var action_ = "sp_edit_url('" + id + "','" + new_name + "');";
            $('#sp-action-' + id).attr("onclick", action_);
            close_box();
        }
    });
    return false;
}


function sp_this_file_delete(id, src) {
    $.ajax({
        type: "POST",
        url: base_ + "Media/DoSPDelete",
        data: "id=" + id + "&src=" + src,
        success: function (rs) {
            $("[src='" + src + "'], [dir='" + src + "'], [src='~" + src + "'], [dir='~" + src + "']").parent().parent().remove();
            close_box();
        }
    });
    return false;
}

function scorePassword(pass) {
    var score = 0;
    if (!pass)
        return score;

    // award every unique letter until 5 repetitions
    var letters = new Object();
    for (var i = 0; i < pass.length; i++) {
        letters[pass[i]] = (letters[pass[i]] || 0) + 1;
        score += 5.0 / letters[pass[i]];
    }

    // bonus points for mixing it up
    var variations = {
        digits: /\d/.test(pass),
        lower: /[a-z]/.test(pass),
        upper: /[A-Z]/.test(pass),
        nonWords: /\W/.test(pass),
    }

    variationCount = 0;
    for (var check in variations) {
        variationCount += (variations[check] == true) ? 1 : 0;
    }
    score += (variationCount - 1) * 10;

    return parseInt(score);
}

function ShowAction(t, a) {
    var child = $(t).attr('data-child');
    var parent = $(t).parent().attr('data-parent');
    var DistinguishedName = $(t).attr("data-id");
    switch (a) {
        case 'User':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/Create/?DistinguishedName=" + DistinguishedName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'Move':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/DirMoveAccount/?DistinguishedName=" + DistinguishedName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'New':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/DirectoryCreate/?DistinguishedName=" + DistinguishedName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'Rename':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/DirectoryRename/?Parent=" + parent + "&Child=" + child,
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'Delete':
            o_str_ = '<div class="modal-header header-color">' +
                                    '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                    '<h4 class="modal-title">Confirmation</h4>' +
                                    '</div>' +
                                    '<div class="modal-body">';
            _message_ = '<p id="on-loading">Are you sure to delete the folder <b>(' + DistinguishedName + ')</b></p>';
            f_str = '<div class="modal-footer">' +
                    '<a href="javascript:void(0)" class="btn btn-default btn-sm" onclick="close_box()">Cancel</a>' +
                    '<button class="btn medium btn-danger btn-sm" id="btn-del">Yes</button>';
            c_str_ = '</div>';
            return_modalbox(o_str_ + _message_ + c_str_ + f_str, 'true', '400px');
            $('#btn-del').click(function () {
                $.ajax({
                    beforeSend: function () {
                        $("#btn-del").html("Please wait...");
                    },
                    type: 'GET',
                    url: '/ActiveDirectory/DirectoryDelete/?Parent=' + parent + '&Child=' + child,
                    success: function () {
                        $(t).attr("data-id", DistinguishedName).remove();
                        close_box();
                    }
                })
            });
            break;
        default:
            break;
    }
}

function ShowActionTable(t, a) {
    var samAccountName = $(t).parent().find("input[name='id']").val();
    switch (a) {
        case 'Delete':
            o_str_ = '<div class="modal-header header-color">' +
                                    '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                    '<h4 class="modal-title">Confirmation</h4>' +
                                    '</div>' +
                                    '<div class="modal-body">';
            _message_ = '<p id="on-loading">Are you sure to delete SamAccountName <b>(' + samAccountName + ')</b></p>';
            f_str = '<div class="modal-footer">' +
                    '<a href="javascript:void(0)" class="btn btn-default btn-sm" onclick="close_box()">Cancel</a>' +
                    '<a class="btn medium btn-danger btn-sm" id="btn-del" ajax-type="GET" ajax="true" socket="true" href="#!/ActiveDirectory/SingleDelete/?samAccountName=' + samAccountName + '">Yes</a>';
            c_str_ = '</div>';
            return_modalbox(o_str_ + _message_ + c_str_ + f_str, 'true', '400px');
            $('#btn-del').click(function () {
                $("#btn-del").html("Please wait...");
            });
            break;
        case 'Properties':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/Details/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '800px');
                }
            });
            break;
        case 'AddtoGroup':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/AddToGroup/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '800px');
                }
            });
            break;
        case 'Rename':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/Rename/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'Password':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/Password/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'Move':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/OUMoveAccount/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'Enable':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "POST",
                url: "/ActiveDirectory/SetEnable/?samAccountName=" + samAccountName,
                success: function (rs) {
                    $(t).parent().find("input[name='isEnable']").val(true);
                    $('a#btnA-' + samAccountName.replace('.', '-')).removeClass('disable').addClass('enable');
                    close_box();
                }
            });
            break;
        case 'Disable':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "POST",
                url: "/ActiveDirectory/SetDisable/?samAccountName=" + samAccountName,
                success: function (rs) {
                    $(t).parent().find("input[name='isEnable']").val(false);
                    $('a#btnA-' + samAccountName.replace('.', '-')).removeClass('enable').addClass('disable');
                    close_box();
                }
            });
            break;
        case 'Edit':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/AdvanceEdit/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '800px');
                }
            });
            break;
        default:
            break;
    }
}
function removeExtractResult(t, _url, _target) {
    $(t).parent().parent().remove();
    $.ajax({
        type: "GET",
        beforeSend: function () {
            loading();
        },
        url: _url,
        success: function (rs) {
            $(_target).html(rs);
            window.location.hash = '#!' + path;
        }
    })
}
function ShowActionGroup(t, a) {
    var child = $(t).attr('data-child');
    var parent = $(t).parent().attr('data-parent');
    var DistinguishedName = $(t).attr("data-id");
    switch (a) {
        case 'Group':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/GroupCreate/?DistinguishedName=" + DistinguishedName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '800px');
                }
            });
            break;
        case 'New':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/DirectoryCreate/?DistinguishedName=" + DistinguishedName + "&type=1",
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'Rename':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/DirectoryRename/?Parent=" + parent + "&Child=" + child + "&type=1",
                success: function (rs) {
                    return_bodybox(rs, 'false', '350px');
                }
            });
            break;
        case 'Delete':
            o_str_ = '<div class="modal-header header-color">' +
                                    '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                    '<h4 class="modal-title">Confirmation</h4>' +
                                    '</div>' +
                                    '<div class="modal-body">';
            _message_ = '<p id="on-loading">Are you sure to delete the folder <b>(' + DistinguishedName + ')</b></p>';
            f_str = '<div class="modal-footer">' +
                    '<a href="javascript:void(0)" class="btn btn-default btn-sm" onclick="close_box()">Cancel</a>' +
                    '<button class="btn medium btn-danger btn-sm" id="btn-del">Yes</button>';
            c_str_ = '</div>';
            return_modalbox(o_str_ + _message_ + c_str_ + f_str, 'true', '400px');
            $('#btn-del').click(function () {
                $.ajax({
                    beforeSend: function () {
                        $("#btn-del").html("Please wait...");
                    },
                    type: 'GET',
                    url: '/ActiveDirectory/DirectoryDelete/?Parent=' + parent + '&Child=' + child,
                    success: function () {
                        $(t).attr("data-id", DistinguishedName).remove();
                        close_box();
                    }
                })
            });
            break;
        default:
            break;
    }
}

function ShowActionTableGroup(t, a) {
    var samAccountName = $(t).parent().find("input[name='id']").val();
    switch (a) {
        case 'Delete':
            o_str_ = '<div class="modal-header header-color">' +
                                    '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                    '<h4 class="modal-title">Confirmation</h4>' +
                                    '</div>' +
                                    '<div class="modal-body">';
            _message_ = '<p id="on-loading">Are you sure to delete Group <b>(' + samAccountName + ')</b></p>';
            f_str = '<div class="modal-footer">' +
                    '<a href="javascript:void(0)" class="btn btn-default btn-sm" onclick="close_box()">Cancel</a>' +
                    '<a class="btn medium btn-danger btn-sm" id="btn-del" ajax-type="GET" ajax="true" socket="true" href="#!/ActiveDirectory/SingleGroupDelete/?samAccountName=' + samAccountName + '">Yes</a>';
            c_str_ = '</div>';
            return_modalbox(o_str_ + _message_ + c_str_ + f_str, 'true', '400px');
            $('#btn-del').click(function () {
                $("#btn-del").html("Please wait...");
            });
            break;
        case 'Create':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/AddGroupMember/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '850px');
                }
            });
            break;
        case 'Properties':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/GroupDetails/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '600px');
                }
            });
            break;
        case 'Rename':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/GroupRename/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '800px');
                }
            });
            break;
        case 'Edit':
            $.ajax({
                beforeSend: function () {
                    loading();
                },
                type: "GET",
                url: "/ActiveDirectory/AdvanceGroupEdit/?samAccountName=" + samAccountName,
                success: function (rs) {
                    return_bodybox(rs, 'false', '800px');
                }
            });
            break;
        default:
            break;
    }
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}
function retrieve_cookie(name) {
    var cookie_value = "",
		current_cookie = "",
		name_expr = name + "=",
		all_cookies = document.cookie.split(';'),
		n = all_cookies.length;

    for (var i = 0; i < n; i++) {
        current_cookie = all_cookies[i].trim();
        if (current_cookie.indexOf(name_expr) == 0) {
            cookie_value = current_cookie.substring(name_expr.length, current_cookie.length);
            break;
        }
    }
    return cookie_value;
}
function getCookie(s) {
    var c_name = md5(s);
    var val_ = retrieve_cookie(c_name);
    return val_;
}
setInterval(function () {
    if (getCookie("EnableSkype") == "true") {
        $('.menu-skype').show();
    } else {
        $('.menu-skype').hide();
    } 
    if (getCookie("EnableExchange") == "true") {
        $('.menu-exchange').show();
    } else {
        $('.menu-exchange').hide();
    } 
    if (getCookie("EnableSharepoint") == "true") {
        $('.menu-sharepoint').show();
    } else {
        $('.menu-sharepoint').hide();
    }
    if (getCookie("EnableSkype") == "true") {
        $('span#my-presence, li#noprevent').show();
    } else {
        $('span#my-presence, li#noprevent').hide();
    }
    if (getCookie("EnableSkype") == "true") {
        $('#toogle-app-chat, #right-sidebar').show();
    } else {
        $('#toogle-app-chat, #right-sidebar').hide();
    }

    if (getCookie("syncTime") == '') {
        $.ajax({
            url: '/Apps/GetTimeSync',
            success: function (rs) {
                location.reload();
            }
        })
    } else {
        var syncTime = getCookie("syncTime").split("#");
        for (var i = 0; i < syncTime.length; i++) {
            if (i != 0) {
                var currentdate = new Date();
                var tm = currentdate.getMinutes();
                var hw = currentdate.getHours();
                var time_ = "";
                var hour_ = "";
                if (tm < 10) {
                    time_ += "0" + currentdate.getMinutes();
                } else {
                    time_ += currentdate.getMinutes();
                }
                if (hw < 10) {
                    hour_ += "0" + currentdate.getHours();
                } else {
                    hour_ += currentdate.getHours();
                }
                var current = hour_ + ":" + time_;
                var sX = syncTime[i].split('-')[1].split(':');
                if (current == sX[0] + ':' + sX[1]) {
                    var cls = "sync-apps";
                    if (!$('body').hasClass(cls)) {
                        var id = syncTime[i].split('-')[0];
                        $('body').addClass(cls);
                        $('iframe#syncIframe').remove();
                        $('#syncinprocess').show();
                        $('body').append('<iframe id="syncIframe" style="display:none;" src="/Apps/DoSync/?id=' + id + '"></iframe>');
                        o_str_ = '<div class="modal-header header-color">' + '<button type="button" class="close" onclick="close_box()" data-dismiss="modal" aria-hidden="true">&times;</button>' + '<h4 class="modal-title">Syncronizing..</h4>' + '</div>' + '<div class="modal-body">';
                        c_str_ = '</div>';
                        return_modalbox(o_str_ + '<p style="text-align:justify"><b>Do not refresh browser!</b>, because the application system is syncronizing </p>' + "<div style='margin: 50px auto; width:84px'>" + loading_ + "</div><p>While system is syncronizing you can access other module or do something inside system. But remember <b>Do not refresh the browser!</b></p>" + c_str_, 'false', '400px');
                    }
                }
            }
        }
    }
}, 1000)

function enableAccount(t, _data, id, url_, type) {
    $(_data).validation();
    if (!$(_data).validate()) {
    } else {
        $.ajax({
            beforeSend: function () {
                $(t).find('span').html('Processing..');
            },
            url: url_,
            type: 'POST',
            data: $(_data).serialize(),
            success: function (rs) {
                switch (type) {
                    case 'skype':
                        $(id).removeClass('btn-default').addClass('btn-skype');
                        break;
                    case 'sharepoint':
                        $(id).removeClass('btn-default').addClass('btn-sharepoint');
                        break;
                    case 'exchange':
                        $(id).removeClass('btn-default').addClass('btn-exchange');
                        break;
                    default:
                        break;
                }
                wsSend(rs);
                close_box();
            }
        });
    }
}


function addToTag(email, username) {
    var check_ = $('ul.tagit').find('input[value="' + username + '"]').length;
    if (check_ === 0) {
        var str = '<li class="tagit-choice ui-widget-content ui-state-default ui-corner-all tagit-choice-editable"><input type="hidden" name="SamAccountName" value="' + username + '"><span class="tagit-label">' + email + '</span><a class="tagit-close"><span class="text-icon">&times;</span><span class="ui-icon ui-icon-close"></span></a></li>';
        $('ul.tagit').prepend(str);
        $('.tagit-close').click(function (e) {
            $(this).parent().remove();
        });
    }
    close_box();
}
$(function () {
    $('input[name="awesome-search"]').keyup(function (e) {
        var code = e.which; // recommended to use e.which, it's normalized across browsers
        if (code == 13) e.preventDefault();
        if (code == 32 || code == 13 || code == 188 || code == 186) {
            if ($(this).val().length > 4) {
                setAwesomeSearch($(this).val())
                searchAwesome($(this).val());
            }
        } // missing closing if brace 
    }).change(function (e) {
        if ($(this).val().length > 4) {
            setAwesomeSearch($(this).val())
            searchAwesome($(this).val());
        }
    });
    $('input[name="awesome-search"]').focus(function () {
        $('#full-awesomesearch').css({
            "position": "absolute",
            "width": "100%",
            "min-height": $("#wrapper").height() - 100 + "px",
            "overflow": "hidden",
            "background": "#fff",
            "z-index": "101",
            "left": "0px"
        }).show();
        if ($('#full-awesomesearch').html().length == 0) {
            $.ajax({
                url: "/AwesomeSearch/Index",
                beforeSend: function () {

                },
                type: "GET",
                success: function (rs) {
                    $('#full-awesomesearch').html(rs);
                }
            })
        }
    })
});

function setAwesomeSearch(textSearch) {
    var inp = $('input[name="awesome-search"]');
    searchAwesome(textSearch);
    inp.val(textSearch);
    inp.parent().parent().find(".fa-search").removeClass("fa-search").addClass("fa-times").css({
        "color": "#fff",
        "background": "#ccc",
        "border-radius": "50%",
        "padding": "5px 7px",
        "top": "7px",
        "font-size": "12px",
        "cursor": "pointer"
    }).click(function () {
        $(this).removeAttr("style").removeClass("fa-times").addClass("fa-search").parent().find("input").removeAttr("style").removeAttr("disabled").val("");
        $('#tab-unprovisioning, #tab-provisioning, #tab-user').html("");
        $('a[href="#tab-unprovisioning"], a[href="#tab-provisioning"], a[href="#tab-user"]').find('span').remove();
        $('a[href="#tab-home"]').click();
    });
}

function searchAwesome(text) {
    if (text.charAt(0) == "@") {
        $('a[href="#tab-user"]').click();
        $.ajax({
            beforeSend: function () {
                $('#tab-user').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                $('a[href="#tab-user"]').find('span').html(animate_small);
            },
            url: "/AwesomeSearch/Find",
            type: "POST",
            data: "query=" + text,
            success: function (rs) {
                var sp = rs.split("{0}");
                $('a[href="#tab-user"]').find('span').remove();
                $('a[href="#tab-user"]').append(sp[0]);
                $('#tab-user').html(sp[1]);
            }
        })
    } else {
        switch (text.toLowerCase()) {
            case 'all unprovisioning':
            case 'unprovisioning':
                $('a[href="#tab-unprovisioning"]').click();
                $.ajax({
                    beforeSend: function () {
                        $('#tab-unprovisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                        $('a[href="#tab-unprovisioning"]').find('span').html(animate_small);
                    },
                    url: "/AwesomeSearch/Find",
                    type: "POST",
                    data: "query=" + text,
                    success: function (rs) {
                        var sp = rs.split("{0}");
                        $('a[href="#tab-unprovisioning"]').find('span').remove();
                        $('a[href="#tab-unprovisioning"]').append(sp[0]);
                        $('#tab-unprovisioning').html(sp[1]);
                    }
                })
                break;
            case 'all provisioning':
            case 'provisioning':
                $('a[href="#tab-provisioning"]').click();
                $.ajax({
                    beforeSend: function () {
                        $('#tab-provisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                        $('a[href="#tab-provisioning"]').find('span').html(animate_small);
                    },
                    url: "/AwesomeSearch/Find",
                    type: "POST",
                    data: "query=" + text,
                    success: function (rs) {
                        var sp = rs.split("{0}");
                        $('a[href="#tab-provisioning"]').find('span').remove();
                        $('a[href="#tab-provisioning"]').append(sp[0]);
                        $('#tab-provisioning').html(sp[1]);
                    }
                })
                break;
            case 'unprovisioning in exchange':
            case 'unprovisioning exchange':
                $('a[href="#tab-unprovisioning"]').click();
                $.ajax({
                    beforeSend: function () {
                        $('#tab-unprovisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                        $('a[href="#tab-unprovisioning"]').find('span').html(animate_small);
                    },
                    url: "/AwesomeSearch/Find",
                    type: "POST",
                    data: "query=" + text,
                    success: function (rs) {
                        var sp = rs.split("{0}");
                        $('a[href="#tab-unprovisioning"]').find('span').remove();
                        $('a[href="#tab-unprovisioning"]').append(sp[0]);
                        $('#tab-unprovisioning').html(sp[1]);
                    }
                })
                break;
            case 'provisioning in exchange':
            case 'provisioning exchange':
            case 'exchange':
                $('a[href="#tab-provisioning"]').click();
                $.ajax({
                    beforeSend: function () {
                        $('#tab-provisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                        $('a[href="#tab-provisioning"]').find('span').html(animate_small);
                    },
                    url: "/AwesomeSearch/Find",
                    type: "POST",
                    data: "query=" + text,
                    success: function (rs) {
                        var sp = rs.split("{0}");
                        $('a[href="#tab-provisioning"]').find('span').remove();
                        $('a[href="#tab-provisioning"]').append(sp[0]);
                        $('#tab-provisioning').html(sp[1]);
                    }
                })
                break;
            case 'unprovisioning in sharepoint':
            case 'unprovisioning sharepoint':
                $('a[href="#tab-unprovisioning"]').click();
                $.ajax({
                    beforeSend: function () {
                        $('#tab-unprovisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                        $('a[href="#tab-unprovisioning"]').find('span').html(animate_small);
                    },
                    url: "/AwesomeSearch/Find",
                    type: "POST",
                    data: "query=" + text,
                    success: function (rs) {
                        var sp = rs.split("{0}");
                        $('a[href="#tab-unprovisioning"]').find('span').remove();
                        $('a[href="#tab-unprovisioning"]').append(sp[0]);
                        $('#tab-unprovisioning').html(sp[1]);
                    }
                })
                break;
            case 'provisioning in sharepoint':
            case 'provisioning sharepoint':
            case 'sharepoint':
                $('a[href="#tab-provisioning"]').click();
                $.ajax({
                    beforeSend: function () {
                        $('#tab-provisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                        $('a[href="#tab-provisioning"]').find('span').html(animate_small);
                    },
                    url: "/AwesomeSearch/Find",
                    type: "POST",
                    data: "query=" + text,
                    success: function (rs) {
                        var sp = rs.split("{0}");
                        $('a[href="#tab-provisioning"]').find('span').remove();
                        $('a[href="#tab-provisioning"]').append(sp[0]);
                        $('#tab-provisioning').html(sp[1]);
                    }
                })
                break;
            case 'unprovisioning in skype':
            case 'unprovisioning skype':
                $('a[href="#tab-unprovisioning"]').click();
                $.ajax({
                    beforeSend: function () {
                        $('#tab-unprovisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                        $('a[href="#tab-unprovisioning"]').find('span').html(animate_small);
                    },
                    url: "/AwesomeSearch/Find",
                    type: "POST",
                    data: "query=" + text,
                    success: function (rs) {
                        var sp = rs.split("{0}");
                        $('a[href="#tab-unprovisioning"]').find('span').remove();
                        $('a[href="#tab-unprovisioning"]').append(sp[0]);
                        $('#tab-unprovisioning').html(sp[1]);
                    }
                })
                break;
            case 'provisioning in skype':
            case 'provisioning skype':
            case 'skype':
                $('a[href="#tab-provisioning"]').click();
                $.ajax({
                    beforeSend: function () {
                        $('#tab-provisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                        $('a[href="#tab-provisioning"]').find('span').html(animate_small);
                    },
                    url: "/AwesomeSearch/Find",
                    type: "POST",
                    data: "query=" + text,
                    success: function (rs) {
                        var sp = rs.split("{0}");
                        $('a[href="#tab-provisioning"]').find('span').remove();
                        $('a[href="#tab-provisioning"]').append(sp[0]);
                        $('#tab-provisioning').html(sp[1]);
                    }
                })
                break;
            default:
                $('a[href="#tab-unprovisioning"]').click();

                $('#tab-unprovisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                $('#tab-provisioning').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                $('#tab-user').html("<div style='margin: 150px auto; width:300px'>" + loading_ + "</div>");
                setTimeout(function () {
                    $('a[href="#tab-unprovisioning"]').find('span').html(" / <sup>0</sup>");
                    $('a[href="#tab-provisioning"]').find('span').html(" / <sup>0</sup>");
                    $('a[href="#tab-user"]').find('span').html(" / <sup>0</sup>");

                    $('#tab-unprovisioning').html("<div style='margin: 150px auto; width:300px'><h3>No results were found.</h3></div>");
                    $('#tab-provisioning').html("<div style='margin: 150px auto; width:300px'><h3>No results were found.</h3></div>");
                    $('#tab-user').html("<div style='margin: 150px auto; width:300px'><h3>No results were found.</h3></div>");
                }, 1000);
                break;
        }
    }

}

function selfTogle(t) {
    $(t).parent().parent().find('.slideToggle').slideToggle('slow');
}

function notDel(t, id) {
    $.ajax({
        type: "GET",
        beforeSend: function () {
            $(t).html('...');
        },
        url: "/Notice/Delete/?id=" + id,
        success: function () {
            $(t).parent().parent().parent().parent().remove();
        }
    });
}