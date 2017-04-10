function _append_to_image_editor_(i) {
    var uri = $(i).attr('src').replace("/small/","/"); 
    var topparent = $("html#ca", window.parent.document).find('iframe#x-editor-iframe').contents().find('body');
            topparent.find('form#x-eimage input[name="i_source"]').val(uri); 
            close_box('iframe'); 
}