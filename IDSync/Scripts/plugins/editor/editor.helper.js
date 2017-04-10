//open window
function eWindow(target, width, height, sCmd, id) {
    $.ajax({
        type: 'post',
        url: base_ + 'Editor/Iframe/',
        data: 'url=/' + target+"&sCmd=" + sCmd + '&width=' + width + '&height=' + height,
        success: function(rs) {
            $('#iframe-box, .x-e-arrow-up').remove();
            $('#' + id).parent().find('.x-editor-block #' + sCmd).prepend('<div class="x-e-arrow-up"></div><div id="iframe-box"></div>');
            $('#iframe-box').html(rs);
        }
    });
}

function selfNode()
{
    if (document.selection)
        return document.selection.createRange().parentElement();
    else
    {
        var selection = window.getSelection();
        if (selection.rangeCount > 0)
            return selection.getRangeAt(0).startContainer.parentNode;
    }
}

// get parentnode in visual text
function parentNode(parentName, childObj) {
    var getOBJ = childObj.parentNode;
    var chained = '';
    while (getOBJ.nodeName !== parentName) {
        getOBJ = getOBJ.parentNode;
        chained += getOBJ.nodeName + '#';
    }
    rt = '';
    lc = chained.split('#');
    for (i = lc.length; i >= -1; i--) {
        if (lc[i] !== undefined && lc[i] !== '') {
            rt += '&raquo;&nbsp;' + lc[i].toLowerCase() + '&nbsp;';
        }
    }
    if (lc.length > 0) {
        return rt + '&raquo;&nbsp;' + thisNode().parentNode.nodeName.toLowerCase();
    }
}
// view document format
function formatDoc(sCmd, sValue, oDoc) {
    if (validateMode(oDoc)) {
        try {
            document.execCommand(sCmd, false, sValue);
            $(oDoc).focus();
        } catch (e) {
            alert(e);
        }

    }
}
// make validation
function validateMode(oDoc) {
    if (!$(oDoc + ' input#swicthMode').checked) {
        return true;
    }
    alert("Uncheck \"Show HTML\".");
    return false;
}

// select mode
function select(i, sCmd) {
    document.execCommand(sCmd, false, $(i).val());
    $(i).val(0);
}

// set document mode
function setDocMode(bToSource, iDoc) {
    var oContent;
    tb = iDoc.split('#');
    var oDoc = '#' + iDoc;
    if (bToSource.checked) {
        oContent = $(oDoc).html();
        $('#' + tb['0'] + ' #toolbar1 , #' + tb['0'] + ' #toolbar2').hide();
        $(oDoc).attr('contentEditable', false).html('');
        oPre = $(oDoc).html('<textarea id="sourceText" wrap="hard"></textarea>');
        $('textarea#sourceText').val(oContent).wrap('<div></div>');
        $(bToSource).attr('original-title', 'view html');

        // auto adjust the height of
        $(oDoc).on('keyup', 'textarea#sourceText', function(e) {
            $(this).css('height', 'auto');
            $(this).height(this.scrollHeight);
        });
        $(oDoc).find('textarea#sourceText').keyup();

    } else {
        $('#' + tb['0'] + ' #toolbar1 ,#' + tb['0'] + ' #toolbar2').show();
        oPre = $('textarea#sourceText');
        oPreContent = oPre.val().toString();
        oPre.remove();
        $(oDoc).attr('contentEditable', true).html(oPreContent);
        $(bToSource).attr('original-title', 'view script');
    }
}

// appen url
function _append_editor_uri(i) {
    var uri = $(i).attr('id');
    $('form#x-elink input[name="l_url"]"', frames['x-editor-iframe'].document).val(uri);
    close_box();
    delete uri;
}
// close iframe
function closeIframe() {
    $('#iframe-box, .x-e-arrow-up').remove();
}
// get current node
function thisNode()
{
    if (document.selection) {
        return document.selection.createRange().parentElement();
    }
    else
    {
        var selection = window.getSelection();
        if (selection.rangeCount > 0)
            return selection.getRangeAt(0).startContainer;
    }
}