(function(a) {
    var b = function() {
        var b = {
            email: {
                check: function(a) {
                    if (a)
                        return c(a, "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])");
                    return true;
                },
                msg: "Enter the correct email address."
            },
            url: {
                check: function(a) {
                    if (a)
                        return c(a, "^https?://(.+.)+.{2,4}(/.*)?$");
                    return true;
                },
                msg: "Fill with correct URL address."
            },
            caracter: {
                check: function(a) {
                    var b = new RegExp("^[a-zA-Z0-9-/￿s_]+$");
                    if (a.match(b))
                        return true;
                    else
                        return false;
                },
                msg: "Please fill without special characters."
            },
            number: {
                check: function(a) {
                    var b = new RegExp("^[0-9]+$");
                    if (a.match(b))
                        return true;
                    else
                        return false;
                },
                msg: "Fill with number [0-9]."
            },
            limit: {
                check: function(a) {
                    var b = new RegExp("^.{3,30}$");
                    if (a.match(b))
                        return true;
                    else
                        return false;
                },
                msg: "Character limit, min(3) max(30)."
            },
            max64: {
                check: function (a) {
                    var b = new RegExp("^.{3,64}$");
                    if (a.match(b))
                        return true;
                    else
                        return false;
                },
                msg: "Character limit, min(3) max(64)."
            },
            required: {
                check: function(a) {
                    if (a === '') {
                        return false;
                    } else if (a)
                        return true;
                    else
                        return false;
                },
                msg: "This field is required."
            },
            captch: {
                check: function(b) {
                    conf = a("input[name='captcha']").val();
                    if (b === conf)
                        return true;
                    else
                        return false;
                },
                msg: "Captcha code is wrong."
            },
            confirm: {
                check: function(b) {
                    conf = a("input[name='confirm'],input[name='password']").val();
                    if (b === conf)
                        return true;
                    else
                        return false;
                },
                msg: "Password confirmation is not match."
            }
        };

        var c = function(a, b) {
            var c = new RegExp(b, "");
            return c.test(a);
        };

        return{
            addRule: function(a, c) {
                b[a] = c;
            },
            getRule: function(a) {
                return b[a];
            }
        };
    };

    var c = function(b) {
        var c = [];
        b.find("[validation]").each(function() {
            var b = a(this);
            if (b.attr("validation") !== undefined) {
                c.push(new d(b));
            }
        });
        this.fields = c;
    };

    c.prototype = {
        validate: function() {
            for (field in this.fields) {
                this.fields[field].validate();
            }
        },
        isValid: function() {
            for (field in this.fields) {
                if (!this.fields[field].valid) {
                    this.fields[field].field.focus();
                    return false;
                }
            }
            return true;
        }
    };

    var d = function(a) {
        this.field = a;
        this.valid = false;
        this.attach("change");
    };

    d.prototype = {
        attach: function(a) {
            var b = this;
            if (a === "change") {
                b.field.bind("change", function() {
                    return b.validate();
                });
            }
            if (a === "keyup") {
                b.field.bind("keyup", function(a) {
                    return b.validate();
                });
            }
        },
        validate: function() {
            var b = this, c = b.field, d = "xerrorlist fa fa-warning", e = a(document.createElement("span")).addClass(d), f = c.attr("validation").split("|"), g = c.parent(), h = [];
            c.next(".xerrorlist").remove();
            for (var i in f) {
                var j = a.Validation.getRule(f[i]);
                if (!j.check(c.val())) {
                    g.addClass("error").css({
                        'position': 'relative'
                    });
                    h.push(j.msg)
                }
            }
            if (h.length) {
                b.field.unbind("keyup");
                b.attach("keyup");
                c.after(e.empty());
                for (error in h) {
                    e.addClass('tip-bottom-right');
                    if (e.parent().find('.x-editor-initiator').length > 0) {
                        e.css({
                            'top':'40px',
                            'bottom': '0px'
                        });
                    }
                    if (e.parent().find('.x-tag').length > 0) {
                        e.css({
                            'bottom': '13px'
                        });
                    }
                    e.attr({
                        "title": h[error],
                        "data-toggle":"tooltip",
                        "data-placement":"top",
                        "tip-type": 'error'
                    });
                }
                b.valid = false;
            } else {
                e.remove();
                g.removeClass("error");
                b.valid = true;
            }
            $('[data-toggle="tooltip"]').tooltip();
        }
    };

    a.extend(a.fn, {
        validation: function() {
            var b = new c(a(this));
            a.data(a(this)[0], "validator", b);
            a(this).bind("submit", function(a) {
                b.validate();
                if (!b.isValid()) {
                    a.preventDefault();
                }
            });
        },
        validate: function() {
            var b = a.data(a(this)[0], "validator");
            b.validate();
            return b.isValid();
        }
    });
    a.Validation = new b;
})(jQuery);