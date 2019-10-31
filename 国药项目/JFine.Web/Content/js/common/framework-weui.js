
$(function () {
    $(".jf-action-back").click(function () {
        history.back();
    });
})

var oldFnTab = $.fn.tab;
$.fn.tab = function (options) {
    options = $.extend({
        defaultIndex: 0,
        activeClass: 'weui_bar_item_on',
        onToggle: $.noop
    }, options);
    const $tabbarItems = this.children().children('.weui_tabbar_item, .weui_navbar_item');
    const $tabBdItems = this.children().children('.weui_tab_bd_item');
    this.toggle = function (index) {
        const $defaultTabbarItem = $tabbarItems.eq(index);
        if ($defaultTabbarItem.hasClass(options.activeClass)) {
            return;
        }
        $defaultTabbarItem.addClass(options.activeClass).siblings().removeClass(options.activeClass);
        const $defaultTabBdItem = $tabBdItems.eq(index);
        $defaultTabBdItem.show().siblings('.weui_tab_bd_item').hide();
        options.onToggle(index);
    };
    const self = this;
    this.children().children('.weui_tabbar_item, .weui_navbar_item').on('click', function (e) {
        const index = $(this).index();
        self.toggle(index);
    });
    this.toggle(options.defaultIndex);
    return this;
};
$.fn.tab.noConflict = function () {
    return oldFnTab;
};

$.get = function (name) {
    if (typeof (Storage) !== 'undefined') {
        return localStorage.getItem(name)
    } else {
        window.alert('请用新版浏览器，推荐最新版火狐!')
    }
}

$.store = function (name, val) {
    if (typeof (Storage) !== 'undefined') {
        localStorage.setItem(name, val)
    } else {
        window.alert('请用新版浏览器，推荐最新版火狐!')
    }
}
$.reload = function () {
    location.reload();
    return false;
}

$.request = function (name) {
    var search = location.search.slice(1);
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("=");
        if (ar[0] == name) {
            if (decodeURI(ar[1]) == 'undefined') {
                return "";
            } else {
                return decodeURI(ar[1]);
            }
        }
    }
    return "";
}

$.weuiSubmitAjax = function (options) {
    var defaults = {
        url: "",
        param: [],
        loading: "正在提交数据...",
        success: null,
        fail: null
    };
    var options = $.extend(defaults, options);
    $.showLoading(options.loading);
    window.setTimeout(function () {
        if ($('[name=__RequestVerificationToken]').length > 0) {
            options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
        }
        $.ajax({
            url: options.url,
            data: options.param,
            type: "post",
            dataType: "json",
            success: function (data) {
                $.hideLoading();
                if (data.state == "success") {
                    options.success(data);
                    $.toptip(data.message, 'success');
                } else {
                    $.toptip(data.message, 'error');
                    options.fail(data);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.hideLoading();
                $.toast(errorThrown, "forbidden");
            },
            beforeSend: function () {
                $.showLoading(options.loading);
            },
            complete: function () {
                $.hideLoading();
            }
        });
    }, 50);
}
$.weuiDeleteForm = function (options) {
    var defaults = {
        prompt: "注：您确定要删除该项数据吗？",
        promptTitle: "确认删除?",
        url: "",
        param: [],
        loading: "正在删除数据...",
        success: null,
        close: true
    };
    var options = $.extend(defaults, options);
    if ($('[name=__RequestVerificationToken]').length > 0) {
        options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    $.confirm(options.prompt, options.promptTitle, function () {
        $.showLoading(options.loading);
        window.setTimeout(function () {
            $.ajax({
                url: options.url,
                data: options.param,
                type: "post",
                dataType: "json",
                success: function (data) {
                    $.hideLoading();
                    if (data.state == "success") {
                        options.success(data);
                        $.toptip(data.message, 'success');
                    } else {
                        $.toptip(data.message, 'error');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.hideLoading();
                    $.toast(errorThrown, "forbidden");
                },
                beforeSend: function () {
                    $.showLoading(options.loading);
                },
                complete: function () {
                    $.hideLoading();
                }
            });
        }, 50);
    }, function () {
        //取消操作
    });

}
$.weuiConfirmSubmitForm = function (options) {
    var defaults = {
        prompt: "您确定要提交数据吗？",
        promptTitle: "确认提交?",
        url: "",
        param: [],
        loading: "正在提交数据...",
        success: null,
        close: true
    };
    var options = $.extend(defaults, options);
    if ($('[name=__RequestVerificationToken]').length > 0) {
        options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    $.confirm(options.prompt, options.promptTitle, function () {
        $.showLoading(options.loading);
        window.setTimeout(function () {
            $.ajax({
                url: options.url,
                data: options.param,
                type: "post",
                dataType: "json",
                success: function (data) {
                    $.hideLoading();
                    if (data.state == "success") {
                        options.success(data);
                        $.toptip(data.message, 'success');
                    } else {
                        $.toptip(data.message, 'error');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.hideLoading();
                    $.toast(errorThrown, "forbidden");
                },
                beforeSend: function () {
                    $.showLoading(options.loading);
                },
                complete: function () {
                    $.hideLoading();
                }
            });
        }, 50);
    }, function () {
        //取消操作
    });

}
$.weuiConfirmSubmitForm2 = function (options) {
    var defaults = {
        prompt: "您确定要提交数据吗？",
        promptTitle: "确认提交?",
        url: "",
        param: [],
        loading: "正在提交数据...",
        success: null,
        close: true
    };
    var options = $.extend(defaults, options);
    if ($('[name=__RequestVerificationToken]').length > 0) {
        options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    $.confirm(options.prompt, options.promptTitle, function () {
        $.showLoading(options.loading);
        window.setTimeout(function () {
            $.ajax({
                url: options.url,
                data: options.param,
                type: "get",
                dataType: "json",
                success: function (data) {
                    $.hideLoading();
                    if (data.state == "success") {
                        options.success(data);
                        $.toptip(data.message, 'success');
                    } else {
                        $.toptip(data.message, 'error');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.hideLoading();
                    $.toast(errorThrown, "forbidden");
                },
                beforeSend: function () {
                    $.showLoading(options.loading);
                },
                complete: function () {
                    $.hideLoading();
                }
            });
        }, 50);
    }, function () {
        //取消操作
    });

}

$.noFindHeadImage = function (image) {
    image.src = "/Content/images/headImage/head-default.png";
    image.onerror = null;
}

$.noFindImage = function (image) {
    image.src = "/Content/images/default.jpg";
    image.onerror = null;
}

$.fn.formValid = function () {
    return $(this).valid({
        errorPlacement: function (error, element) {
            element.siblings('.has-error').remove();
            element.addClass('has-error');
            element.after('<i class="weui-icon-warn has-error" style="display: block; font-size: 16px;">' + error + '</i>');
        },
        success: function (element) {
            element.siblings('.has-error').remove();
            element.removeClass('has-error');
        }
    });
}

$.fn.formSerialize = function (formdate) {
    var element = $(this);
    if (!!formdate) {
        for (var key in formdate) {
            var $id = element.find('#' + key);
            var value = $.trim(formdate[key]).replace(/&nbsp;/g, '');
            var type = $id.attr('type');
            if ($id.hasClass("select2-hidden-accessible")) {
                type = "select";
            }
            switch (type) {
                case "checkbox":
                    if (value == "true") {
                        $id.attr("checked", 'checked');
                    } else {
                        $id.removeAttr("checked");
                    }
                    break;
                case "radio":
                    $("input[name='" + key + "'][value=" + value + "]").attr("checked", true);
                    break;
                case "select":
                    $id.val(value).trigger("change");
                    break;
                default:
                    $id.val(value);
                    break;
            }
        };
        return false;
    }
    var postdata = {};
    element.find('input,select,textarea').each(function (r) {
        var $this = $(this);
        var id = $this.attr('id');
        var type = $this.attr('type');
        switch (type) {
            case "checkbox":
                postdata[id] = $this.is(":checked");
                break;
            case "radio":
                if (id != '' && id != undefined && id != null) {
                    postdata[id] = $("input[name='" + id + "']:checked").val();
                }
                break;
            default:
                //var value = $this.val() == "" ? "&nbsp;" : $this.val();
                var value = ($this.val() == "" || $this.val() == null) ? "&nbsp;" : $this.val();
                if (!$.request("keyValue")) {
                    value = value.replace(/&nbsp;/g, '');
                }
                postdata[id] = value;
                break;
        }
    });
    if ($('[name=__RequestVerificationToken]').length > 0) {
        postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    return postdata;
};
$.fn.formInitialize = function (formdate) {
    var element = $(this);
    if (!!formdate) {
        for (var key in formdate) {
            var $id = element.find('div#' + key);
            var value = $.trim(formdate[key]).replace(/&nbsp;/g, '');
            $id.html(value);
        };
        return false;
    }
};

$.fn.bindWeuiSelect = function (options) {
    var defaults = {
        title: "选择",
        id: "id",
        text: "text",
        url: "",
        param: {},
        items: [],
        onChange: null,
        onClose: null,
        onOpen: null
    };
    var options = $.extend(defaults, options);
    var $element = $(this);
    if (options.url != "") {
        $.ajax({
            url: options.url,
            data: options.param,
            dataType: "json",
            async: false,
            success: function (data) {
                $.each(data, function (i) {
                    $element.append($("<option></option>").val(data[i][options.id]).html(data[i][options.text]));
                    options.items.push({ "title": data[i][options.text], "value": data[i][options.id] });
                });
                $element.select(options);
            }
        });
    } else {
        $element.select(options);
    }
}