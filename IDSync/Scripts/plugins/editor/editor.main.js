/*
 Copyright (c)  2003, www.hadinug.com  All rights reserved.
 Code licensed under the BSD License: http://www.hadinug.com/license/
 http://www.hadinug.com/javascript/editor/
 Version 1.0
 */
/**
 * 
 * @param {type} $
 * @returns {undefined}
 */
(function($) {
    $.fn.x_editor = function(options) { 
        // add library 
        addLib('Scripts/plugins/editor/editor.table.min.js');
        addLib('Scripts/plugins/editor/editor.script.js');
        // add another librarary 
        addLib('Scripts/plugins/editor/editor.helper.js');
        // Establish our default settings
        var settings = $.extend({
            oDoc: "x-editor",
            contextMenu: true,
            focus: true,
            toolbar1: ['bold', 'italic', 'underline', 'strikethrough', 'removeFormat', '|', 'link', 'unlink', '|','word','image', 'audio', 'video', 'table', '|', 'list-ul', 'list-ol', 'fullscreen'],
            toolbar2: ['formatblock', 'fontsize','justifyleft', 'justifycenter', 'justifyright', 'justifyfull', '|', 'subscript', 'superscript', 'hr', '|', 'forecolor', 'hilitecolor', 'emotic']
        }, options);
        return this.each(function() {
            var t = this;
            $(this).hide();
            var d = new Date(), id = d.getTime(), txtDefault = $(this).val(), editor = textNode($(t).height(), (txtDefault) ? txtDefault : '', settings.oDoc, id, settings.toolbar1, settings.toolbar2);
            // append textarea value to new document 
            $(this).parent().prepend(editor);
            var docId = '#' + settings.oDoc;
            if (settings.focus) { 
                $(docId).focus();
            }
            $(docId).on({
                click: function() {
                    if (!$('input#swicthMode').is(":checked")) {
                        vThis = $(this).html();
                    } else {
                        vThis = $('textarea#sourceText').val();
                    }
                    $(t).val(vThis);
                    //$('#iframe-box').html('');
                    $('div.x-e-arrow-up').remove();
                },
                keyup: function (e) {
                    if (e.keyCode === 27) {
                        closeIframe();
                        $('#iframe-box').html('');
                    } 
                    if (!$('input#swicthMode').is(":checked")) {
                        vThis = $(this).html();
                    } else {
                        vThis = $('textarea#sourceText').val();
                    }
                    $(t).val(vThis);
                },
                keydown: function() {
                    if (!$('input#swicthMode').is(":checked")) {
                        vThis = $(this).html();
                    } else {
                        vThis = $('textarea#sourceText').val();
                    }
                    $(t).val(vThis);
                },
                focusin: function() {
                    if (!$('input#swicthMode').is(":checked")) {
                        vThis = $(this).html();
                    } else {
                        vThis = $('textarea#sourceText').val();
                    }
                    $(t).val(vThis);
                },
                focusout: function() {
                    if (!$('input#swicthMode').is(":checked")) {
                        vThis = $(this).html();
                    } else {
                        vThis = $('textarea#sourceText').val();
                    }
                    $(t).val(vThis);
                },
                mousein: function() {
                    if (!$('input#swicthMode').is(":checked")) {
                        vThis = $(this).html();
                    } else {
                        vThis = $('textarea#sourceText').val();
                    }
                    $(t).val(vThis);
                },
                mouseout: function() {
                    if (!$('input#swicthMode').is(":checked")) {
                        vThis = $(this).html();
                    } else {
                        vThis = $('textarea#sourceText').val();
                    }
                    $(t).val(vThis);
                },
                mouseleave: function() {
                    if (!$('input#swicthMode').is(":checked")) {
                        vThis = $(this).html();
                    } else {
                        vThis = $('textarea#sourceText').val();
                    }
                    $(t).val(vThis);
                }
            });


            // make event when
            $(docId).on({
                
                click: function() {
                    $('#' + id + ' #visual-html').html(parentNode('DIV', thisNode()));
                    $("#mouse_menu_right").hide();
                },
                mouseleave: function() {
                    var img = $(this).find('img[click="true"]');
                    img.resizable('destroy').removeAttr('width').removeAttr('class').removeAttr('id').removeAttr('height').css({
                        'top': '', 'left': '', 'border': '', 'position': '', 'resize': '', 'zoom': '', 'display': ''
//                        'width':img.width()-20,
//                        'height':img.height()-20
                    });
                    $(this).find('table').resizable('destroy').removeAttr('width').removeAttr('class').removeAttr('height').css({
                        'top': '', 'left': '', 'border': '', 'position': '', 'resize': '', 'zoom': '', 'display': ''
                    });
                }
            });
            // make even when find the element img anda table

            $(docId).on({
                click: function()
                {
                    tbl = thisNode().parentNode.parentNode.parentNode.nodeName;
                    if (tbl === 'TABLE' || tbl === 'TBODY') {
                        $(docId).find('table').removeAttr('id', 'mainTable');
                        //stuff to do on mouseover
                        $(this).resizable().css({
                            'border': '1px solid #ccc'
                        }).attr('id', 'mainTable');

                    } else {
                        $(docId).find('img').removeAttr('click');
                        //stuff to do on mouseover
                        $(this).resizable().css({
                            'border': '1px solid #ccc'
                        }).attr('click', true);
                    }

                },
                contextmenu: function() {
                    tbl = thisNode().parentNode.parentNode.parentNode.nodeName;
                    if (tbl === 'TABLE' || tbl === 'TBODY') {
                        $(docId).find('table').removeAttr('id', 'mainTable');
                        //stuff to do on mouseover
                        $(this).resizable().css({
                            'border': '1px solid #ccc'
                        }).attr('id', 'mainTable');

                    } else {
                        $(docId).find('img').not(".x-emotic-icon").removeAttr('click');
                        //stuff to do on mouseover
                        $(this).resizable().css({
                            'border': '1px solid #ccc',
                            'float': 'none'
                        }).attr('click', true);
                    }

                },
                mouseleave: function()
                {
                    //stuff to do on mouseleave
                    $(this).css({
                        'border': ''
                    });
                }
            },
            "img:not(.x-emotic-icon), table");
            // when right click
            if (settings.contextMenu) {

                $(".x-editor").bind("contextmenu", function(e) {
                    if ($('input#swicthMode').is(':checked')) {

                    } else {
                        var t = $(this);
                        e.preventDefault();
                        var parentOffset = $(this).parent().offset();
                        //or $(this).offset(); if you really just want the current element's offset
                        var relX = e.pageX - parentOffset.left;
                        var relY = e.pageY - parentOffset.top;
                        $('#mouse_menu_right').css({
                            left: relX,
                            top: relY
                        }).show();
                    }
                    // create and show menu
                });

            }

            // make event on document
            var bTE = $('#' + id).find('a.x-btn-editor');
            // when button editor is click
            bTE.click(function() {
                var sCmd = $(this).attr('id');
                $(docId).focus();
                switch (sCmd) {
                    // when fullscreeen btn is click
                    case 'fullscreen':
                        $('div#' + id).parent().css({
                            'position': ''
                        });
                        $('body').css({
                            'position': 'relative'
                        });
                        $('div#' + id).css({
                            'position': 'fixed', 'left': '-.4%', 'top': '0px', 'background': '#fff', 'z-index': '1000', 'width': '100%', 'margin': '0 0 0 .3%', 'min-height': $(window).height()
                        });
                        $('.x-editor-initiator .x-editor,.x-editor-initiator .x-editor > textarea#sourceText').css({
                            'max-height': $(window).height() - 120,
                            'height': $(window).height() - 120,
                            'overflow': 'auto'
                        }); 
                        $('div#' + id).find('#' + sCmd).hide();
                        $('div#' + id).find('#exit-fullscreen').show();
                        break;
                        // when exit fullscreen btn is click
                    case 'exit-fullscreen':
                        $('body').css({
                            'position': 'static'
                        });
                        $('div#' + id).parent().css({
                            'position': 'relative'
                        });
                        $('.x-editor-initiator .x-editor').css({
                            'height': '252px'
                        });
                        $('body').css({
                            'overflow': 'auto'
                        });
                        $('div#' + id).removeAttr('style');
                        $('div#' + id).find('#' + sCmd).hide();
                        $('div#' + id).find('#fullscreen').show();
                        break;
                        // when forecolor and hilecolor btn is click
                    case  'forecolor':
                    case  'hilitecolor':
                        eWindow('Editor/Colors/', 200, 150, sCmd, settings.oDoc);
                        break;
                        // when emotic icon btn is click 
                    case 'emotic':
                        eWindow('Editor/Emotics/', 255, 170, sCmd, settings.oDoc);
                        break;
                        // when image btn is click
                    case 'image':
                        eWindow('Editor/Image/', 400, 200, sCmd, settings.oDoc);
                        break; 
                        // when audio btn is click
                    case 'audio':
                        eWindow('Editor/Audio/', 400, 125, sCmd, settings.oDoc);
                        break;
                        // when video btn is click
                    case 'video':
                        eWindow('Editor/Video/', 435, 125, sCmd, settings.oDoc);
                        break;
                        // when link btn is click
                    case 'createlink':
                        eWindow('Editor/Link', 400, 130, sCmd, settings.oDoc);
                        break; 
                        // when table btn is click
                    case 'table':
                        eWindow('Editor/Table/', 300, 135, sCmd, settings.oDoc);
                        break;
                    // when word copy
                    case 'word':
                        eWindow('Editor/Word/', 400, 360, sCmd, settings.oDoc);
                        break;
                    case 'removeFormat':
                        document.execCommand('formatblock', false, '<p>');
                        formatDoc(sCmd, null, docId);
                        break; 
                    case 'code':
                        var self_ = selfNode();
                        if ($(self_).find('pre').size() > 0) {
                            document.execCommand('formatblock', false, '<p>');
                        } else {
                            document.execCommand('formatblock', false, '<pre>');
                        }
                        break;
                    case 'hr':
                        document.execCommand('inserthtml', false, '<hr class="editor-split">');
                        break;
                    default:
                        formatDoc(sCmd, null, docId);
                        break;
                }
                // hide right menu option
                $("#mouse_menu_right").hide();
            });
        });
    };
}(jQuery));
/**
 * 
 * @param {type} lib
 * @returns {undefined}
 */
function addLib(lib) {
    var newscript = document.createElement('script');
    newscript.type = 'text/javascript';
    newscript.async = true;
    newscript.src = lib;
    (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(newscript);
}

//make textNode
function textNode(height, txtDef, oDoc, id, t1, t2) {

    return '<div class="x-editor-initiator" id="' + id + '">' +
            getButton(t1, 'toolbar1') +
            getButton(t2, 'toolbar2') +
            '<a href="javascript:void(0);" class="x-html-view x-btn-editor" id="true"><input id="swicthMode" class="tip-bottom-right" original-title="view script" onclick="setDocMode(this,\'' + id + ' #' + oDoc + '\');" type="checkbox"/></a>' +
            '<div id="' + oDoc + '" style="min-height:' + height + 'px;height: 252px;overflow: auto" spellcheck="false" allowtransparency="true" designMode="on" class="x-editor" contenteditable="true">' + txtDef + '</div>' +
            menuclick() +
            '<div id="visual-html">&raquo;&nbsp;div</div>' +
            '</div>';
}
// right menu
var menuclick = function() {
    return '<ul id="mouse_menu_right" class="mouse_menu">' +
            '<li><a href="javascript:void(0)" class="x-btn-editor" id="createlink"><i class="fa fa-link"></i>&nbsp;insert link</a></li>' +
            '<li><a href="javascript:void(0)" class="x-btn-editor" id="image"><i class="fa fa-photo"></i>&nbsp;insert image</a></li>' +
            '<li><a href="javascript:void(0)" class="x-btn-editor" id="table"><i class="fa fa-table"></i>&nbsp;insert table</a></li>' +
            '<li><a href="javascript:void(0)" class="x-btn-editor m-right" onclick="redips.row(\'insert\')">&nbsp;add row</a></li>' +
            '<li><a href="javascript:void(0)" class="x-btn-editor m-right" onclick="redips.row(\'delete\')">&nbsp;delete row</a></li>' +
            '<li><a href="javascript:void(0)" class="x-btn-editor m-right" onclick="redips.column(\'insert\')">&nbsp;add column</a></li>' +
            '<li><a href="javascript:void(0)" class="x-btn-editor m-right" onclick="redips.column(\'delete\')">&nbsp;delete column</a></li>' +
            '</ul>';
};



function cBEditor(id) {
    var _class = id;
    switch (id) {
        case 'justifyleft':
            title = 'align left';
            _class = 'align-left';
            break;
        case 'justifyright':
            title = 'align right';
            _class = 'align-right';
            break;
        case 'justifycenter':
            title = 'align center';
            _class = 'align-center';
            break;
        case 'justifyfull':
            title = 'justify';
            _class = 'align-justify';
            break;
        case 'hilitecolor':
            title = 'hightlight color';
            _class = 'font';
            break;
        case 'insertunorderedlist':
            title = 'list ol';
            _class = 'list-ol';
            break;
        case 'insertorderedlist':
            title = 'list ul';
            _class = 'list-ul';
            break;
        case 'createlink':
            title = 'link';
            _class = 'link';
            break;
        case 'strikethrough':
            title = 'strike through';
            break;
        case 'link-less':
            title = 'link';
            break;
        case 'image-less':
            title = 'image';
            break;
        case 'code':
            title = 'insert script or code';
            break;
        case 'removeFormat':
            title = 'remove format';
            _class = 'eraser';
            break;
        case 'hr':
            title = 'line break';
            _class = 'minus';
            break;
        case 'word':
            title = 'paste from ms word';
            _class = 'file-word-o';
            break;
        case 'video':
            title = 'browse video';
            _class = 'file-video-o';
            break;
        case 'audio':
            title = 'browse audio';
            _class = 'file-audio-o';
            break;
        case 'fullscreen':
            title = 'fullscreen';
            _class = 'external-link';
            break;
        case 'exit-fullscreen':
            title = 'exit fullscreen';
            _class = 'external-link-square';
            break;
        case 'forecolor':
            title = 'forecolor';
            _class = 'font';
            break;
        case 'emotic':
            title = 'icon';
            _class = 'smile-o';
            break;        
        default:
            title = id;
            _class = id;
            break;
    }
    return '<a href="javascript:void(0);" class="x-btn-editor tip-top" original-title="' + title + '" id="' + id + '"><i class="fa fa-' + _class + '"></i></a>';
}

function cBSplit() {
    return '<a href="javascript:void(0);" class="x-btn-split"></a>';
}
var formatblock = function() {
    return '<select id="formatblock" onchange="select(this,\'formatblock\')">' +
            '<option value="<p>">Normal</option>' +
            '<option value="<p>">Paragraph</option>' +
            '<option value="<h1>">Heading 1</option>' +
            '<option value="<h2>">Heading 2</option>' +
            '<option value="<h3>">Heading 3</option>' +
            '<option value="<h4>">Heading 4</option>' +
            '<option value="<h5>">Heading 5</option>' +
            '<option value="<h6>">Heading 6</option>' +
            '<option value="<address>">Address</option>' +
            '<option value="<pre>">Formatted</option> ' +
            '</select>';
};

var fontname = function() {
    return '<select id="fontname" onchange="select(this,\'fontname\')">' +
            '<option class="heading" selected>- font -</option>' +
            '<option value="Arial">Arial</option>' +
            '<option value="Arial Black">Arial Black</option>' +
            '<option value="Courier New">Courier New</option>' +
            '<option value="Times New Roman">Times New Roman</option>' +
            '</select>';
};

var fontsize = function() {
    return '<select id="fontsize" onchange="select(this,\'fontsize\')">' +
            '<option class="heading" selected>- size -</option>' +
            '<option value="1">Very small</option>' +
            '<option value="2">A bit small</option>' +
            '<option value="3">Normal</option>' +
            '<option value="4">Medium-large</option>' +
            '<option value="5">Big</option>' +
            '<option value="6">Very big</option>' +
            '<option value="7">Maximum</option>' +
            '</select>';
};


function getButton(t, type) {
    var toolbar = '';
    for (j = 0; j < t.length; j++) {
        switch (t[j]) {
            case 'formatblock':
                toolbar += formatblock();
                break;
            case 'fontname':
                toolbar += fontname();
                break;
            case 'fontsize':
                toolbar += fontsize();
                break;
            case 'list-ol':
                toolbar += cBEditor('insertorderedlist');
                break;
            case 'list-ul':
                toolbar += cBEditor('insertunorderedlist');
                break;
            case 'link':
                toolbar += cBEditor('createlink');
                break;
            case 'fullscreen':
                toolbar += cBEditor('fullscreen') + cBEditor('exit-fullscreen');
                break
            case '|':
                toolbar += cBSplit();
                break;
            default:
                toolbar += cBEditor(t[j]);
                break;
        }
    }
    switch (type) {
        case 'toolbar1':
            return (toolbar && toolbar !== '') ? '<div class="x-editor-block" id="toolbar1">' +
                    toolbar +
                    '</div>' : '';
            break;
        case 'toolbar2':
            return (toolbar && toolbar !== '') ? '<div class="x-editor-block" id="toolbar2">' +
                    toolbar +
                    '</div>' : '';
            break;
        default:
            break;
    }
} 