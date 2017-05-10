(function ($) {

    //全局系统对象
    window['iTools'] = {};

    iTools.cookies = (function () {
        var fn = function () {
        };
        fn.prototype.get = function (name) {
            var cookieValue = "";
            var search = name + "=";
            if (document.cookie.length > 0) {
                offset = document.cookie.indexOf(search);
                if (offset != -1) {
                    offset += search.length;
                    end = document.cookie.indexOf(";", offset);
                    if (end == -1) end = document.cookie.length;
                    cookieValue = decodeURIComponent(document.cookie.substring(offset, end));
                }
            }
            return cookieValue;
        };
        fn.prototype.set = function (cookieName, cookieValue, DayValue) {
            var expire = "";
            var day_value = 1;
            if (DayValue != null) {
                day_value = DayValue;
            }
            expire = new Date((new Date()).getTime() + day_value * 86400000);
            expire = "; expires=" + expire.toGMTString();
            document.cookie = cookieName + "=" + encodeURIComponent(cookieValue) + ";path=/" + expire;
        }
        fn.prototype.remvoe = function (cookieName) {
            var expire = "";
            expire = new Date((new Date()).getTime() - 1);
            expire = "; expires=" + expire.toGMTString();
            document.cookie = cookieName + "=" + escape("") + ";path=/" + expire;
            /*path=/*/
        };

        return new fn();
    })();

    //右下角的提示框
    iTools.tip = function (message) {
        if (iTools.wintip) {
            iTools.wintip.set('content', message);
            iTools.wintip.show();
        }
        else {
            iTools.wintip = $.ligerDialog.tip({ content: message });
        }
        setTimeout(function () {
            iTools.wintip.hide();
        }, 4000);
    };

    //预加载图片
    iTools.prevLoadImage = function (rootpath, paths) {
        for (var i in paths) {
            $('<img />').attr('src', rootpath + paths[i]);
        }
    };
    //显示loading
    iTools.showLoading = function (message) {
        message = message || "正在加载中...";
        $('body').append("<div class='jloading'>" + message + "</div>");
        $.ligerui.win.mask();
    };
    //隐藏loading
    iTools.hideLoading = function (message) {
        $('body > div.jloading').remove();
        $.ligerui.win.unmask({ id: new Date().getTime() });
    }
    //显示成功提示窗口
    iTools.showSuccess = function (message, callback) {
        if (typeof (message) == "function" || arguments.length == 0) {
            callback = message;
            message = "操作成功!";
        }
        $.ligerDialog.success(message, '提示信息', callback);
    };
    //显示失败提示窗口
    iTools.showError = function (message, callback) {
        if (typeof (message) == "function" || arguments.length == 0) {
            callback = message;
            message = "操作失败!";
        }
        $.ligerDialog.error(message, '提示信息', callback);
    };

    //初始化搜索框
    iTools.searchInit = function (div, self) {
        div.css("position", "absolute");//让这个层可以绝对定位
        //div.css("display", "block");
        div.slideToggle();
        var p = $(self).offset(); //获取这个元素的left和top
        var x = p.left;//获取这个浮动层的left
        var docWidth = $(document).width();//获取网页的宽
        if (x > docWidth - div.width() - 20) {
            x = p.left - div.width();
        }
        div.css("left", x);
        div.css("top", p.top + self.height());
    }

    //预加载dialog的图片
    iTools.prevDialogImage = function (rootPath) {
        rootPath = rootPath || "";
        iTools.prevLoadImage(rootPath + '../Content/ligerUI/skins/Aqua/images/win/', ['dialog-icons.gif']);
        iTools.prevLoadImage(rootPath + '../Content/ligerUI/skins/Gray/images/win/', ['dialogicon.gif']);
    };

    //获取当前页面的MenuNo
    //优先级1：如果页面存在MenuNo的表单元素，那么加载它的值
    //优先级2：加载QueryString，名字为MenuNo的值
    iTools.getPageMenuNo = function () {
        var menuno = $("#MenuNo").val();
        if (!menuno) {
            menuno = getQueryStringByName("MenuNo");
        }
        return menuno;
    };

    //创建按钮
    iTools.createButton = function (options) {
        var p = $.extend({
            appendTo: $('body')
        }, options || {});
        var btn = $('<div class="button button2 buttonnoicon" style="width:60px"><div class="button-l"> </div><div class="button-r"> </div> <span></span></div>');
        if (p.icon) {
            btn.removeClass("buttonnoicon");
            btn.append('<div class="button-icon"> <img src="' + p.icon + '" /> </div> ');
        }
        //绿色皮肤
        if (p.green) {
            btn.removeClass("button2");
        }
        if (p.width) {
            btn.width(p.width);
        }
        if (p.click) {
            btn.click(p.click);
        }
        if (p.text) {
            $("span", btn).html(p.text);
        }
        if (typeof (p.appendTo) == "string") p.appendTo = $(p.appendTo);
        btn.appendTo(p.appendTo);
    };

    //快速设置表单底部默认的按钮:保存、取消
    iTools.setFormDefaultBtn = function (cancleCallback, savedCallback) {
        //表单底部按钮
        var buttons = [];
        if (cancleCallback) {
            buttons.push({ text: '取消', onclick: cancleCallback });
        }
        if (savedCallback) {
            buttons.push({ text: '保存', onclick: savedCallback });
        }
        iTools.addFormButtons(buttons);
    };

    //增加表单底部按钮,比如：保存、取消
    iTools.addFormButtons = function (buttons) {
        if (!buttons) return;
        var formbar = $("body > div.form-bar");
        if (formbar.length == 0)
            formbar = $('<div class="form-bar"><div class="form-bar-inner"></div></div>').appendTo('body');
        if (!(buttons instanceof Array)) {
            buttons = [buttons];
        }
        $(buttons).each(function (i, o) {
            var btn = $('<div class="l-dialog-btn"><div class="l-dialog-btn-l"></div><div class="l-dialog-btn-r"></div><div class="l-dialog-btn-inner"></div></div> ');
            $("div.l-dialog-btn-inner:first", btn).html(o.text || "BUTTON");
            if (o.onclick) {
                btn.bind('click', function () {
                    o.onclick(o);
                });
            }
            if (o.width) {
                btn.width(o.width);
            }
            $("> div:first", formbar).append(btn);
        });
    };

    //填充表单数据
    iTools.loadForm = function (mainform, options, callback) {
        options = options || {};
        if (!mainform)
            mainform = $("form:first");
        var p = $.extend({
            beforeSend: function () {
                iTools.showLoading('正在加载表单数据中...');
            },
            complete: function () {
                iTools.hideLoading();
            },
            success: function (data) {
                var preID = options.preID || "";
                //根据返回的属性名，找到相应ID的表单元素，并赋值
                for (var p in data) {
                    var ele = $("[name=" + (preID + p) + "]", mainform);
                    //针对复选框和单选框 处理
                    if (ele.is(":checkbox,:radio")) {
                        ele[0].checked = data[p] ? true : false;
                    }
                    else {
                        ele.val(data[p]);
                    }
                }
                //下面是更新表单的样式
                var managers = $.ligerui.find($.ligerui.controls.Input);
                for (var i = 0, l = managers.length; i < l; i++) {
                    //改变了表单的值，需要调用这个方法来更新ligerui样式
                    var o = managers[i];
                    o.updateStyle();
                    if (managers[i] instanceof $.ligerui.controls.TextBox)
                        o.checkValue();
                }
                if (callback)
                    callback(data);
            },
            error: function (message) {
                iTools.showError('数据加载失败!<BR>错误信息：' + message);
            }
        }, options);
        iTools.ajax(p);
    };

    //带验证、带loading的提交
    iTools.submitForm = function (mainform, success, error) {
        if (!mainform)
            mainform = $("form:first");
        if (mainform.valid()) {
            mainform.ajaxSubmit({
                dataType: 'json',
                success: success,
                beforeSubmit: function (formData, jqForm, options) {
                    //针对复选框和单选框 处理
                    $(":checkbox,:radio", jqForm).each(function () {
                        if (!existInFormData(formData, this.name)) {
                            formData.push({ name: this.name, type: this.type, value: this.checked });
                        }
                    });
                    for (var i = 0, l = formData.length; i < l; i++) {
                        var o = formData[i];
                        if (o.type == "checkbox" || o.type == "radio") {
                            o.value = $("[name=" + o.name + "]", jqForm)[0].checked ? "true" : "false";
                        }
                    }
                },
                beforeSend: function (a, b, c) {
                    iTools.showLoading('正在保存数据中...');

                },
                complete: function () {
                    iTools.hideLoading();
                },
                error: function (result) {
                    iTools.tip('发现系统错误 <BR>错误码：' + result.status);
                }
            });
        }
        else {
            iTools.showInvalid();
        }
        function existInFormData(formData, name) {
            for (var i = 0, l = formData.length; i < l; i++) {
                var o = formData[i];
                if (o.name == name) return true;
            }
            return false;
        }
    };

    //提示 验证错误信息
    iTools.showInvalid = function (validator) {
        validator = validator || iTools.validator;
        if (!validator) return;
        var message = '<div class="invalid">存在' + validator.errorList.length + '个字段验证不通过，请检查!</div>';
        //top.iTools.tip(message);
        $.ligerDialog.error(message);
    };

    //表单验证
    iTools.validate = function (form, options, distance) {
        if (typeof (form) == "string")
            form = $(form);
        else if (typeof (form) == "object" && form.NodeType == 1)
            form = $(form);

        options = $.extend({
            errorPlacement: function (lable, element) {
                if (!element.attr("id"))
                    element.attr("id", new Date().getTime());
                if (element.hasClass("l-textarea")) {
                    element.addClass("l-textarea-invalid");
                }
                else if (element.hasClass("l-text-field")) {
                    element.parent().addClass("l-text-invalid");
                }
                $(element).removeAttr("title").ligerHideTip();
                //设置弹出样式
                if (distance)
                    var options = { distanceX: distance.left + 10, distanceY: distance.top + 25, auto: true }
                else
                    var options = { distanceX: 5, distanceY: -3, auto: true };
                $(element).attr("title", lable.html()).ligerTip(options);
            },
            success: function (lable) {
                if (!lable.attr("for")) return;
                var element = $("#" + lable.attr("for"));

                if (element.hasClass("l-textarea")) {
                    element.removeClass("l-textarea-invalid");
                }
                else if (element.hasClass("l-text-field")) {
                    element.parent().removeClass("l-text-invalid");
                }
                $(element).removeAttr("title").ligerHideTip();
            }
        }, options || {});
        iTools.validator = form.validate(options);
        return iTools.validator;
    };

    //三个参数,第三个为默认的菜单元素(一般为不和服务器发生交互的菜单按钮)
    iTools.loadToolbar = function (grid, toolbarBtnItemClick, toolbarDefaultOptions) {
        var MenuNo = iTools.getPageMenuNo();
        $.ajax({
            loading: '正在加载工具条中...',
            url: '/Manage/GetMenuButton',
            dataType: 'json',
            data: { MenuNo: MenuNo },
            success: function (data) {
                if (!grid.toolbarManager) return;
                if (!data || !data.length) return;
                var items = [];
                //添加服务端的按钮
                for (var i = 0, l = data.length; i < l; i++) {
                    var o = data[i];
                    items[items.length] = {
                        click: toolbarBtnItemClick,
                        text: o.Name,
                        img: o.Icon,
                        id: o.ActionName
                    };
                    items[items.length] = { line: true };
                }

                if (toolbarDefaultOptions) {
                    for (var i = 0, l = toolbarDefaultOptions.length; i < l; i++) {
                        items[items.length] = {
                            click: toolbarBtnItemClick,
                            text: toolbarDefaultOptions[i].text,
                            img: toolbarDefaultOptions[i].img,
                            id: toolbarDefaultOptions[i].id
                        };
                    }
                }
                //如果客户端存在按钮则添加客户端的按钮(一般代表没有和服务器发生交互的事件)
                grid.toolbarManager.set('items', items);
            }
        });
    };

    //关闭Tab项,如果tabid不指定，那么关闭当前显示的
    iTools.closeCurrentTab = function (tabid) {
        if (!tabid) {
            tabid = $("#framecenter > .l-tab-content > .l-tab-content-item:visible").attr("tabid");
        }
        if (tab) {
            tab.removeTabItem(tabid);
        }
    };

    //关闭Tab项并且刷新父窗口
    iTools.closeAndReloadParent = function (tabid, parentMenuNo) {
        iTools.closeCurrentTab(tabid);
        var menuitem = $("#mainmenu ul.menulist li[menuno=" + parentMenuNo + "]");
        var parentTabid = menuitem.attr("tabid");
        var iframe = window.frames[parentTabid];
        if (tab) {
            tab.selectTabItem(parentTabid);
        }
        if (iframe && iframe.f_reload) {
            iframe.f_reload();
        }
        else if (tab) {
            tab.reload(parentTabid);
        }
    };

    //覆盖页面grid的loading效果
    iTools.overrideGridLoading = function () {
        $.extend($.ligerDefaults.Grid, {
            onloading: function () {
                iTools.showLoading('正在加载表格数据中...');
            },
            onloaded: function () {
                iTools.hideLoading();
            }
        });
    };

    //根据字段权限调整 页面配置
    iTools.adujestConfig = function (config, forbidFields) {
        if (config.Form && config.Form.fields) {
            for (var i = config.Form.fields.length - 1; i >= 0; i--) {
                var field = config.Form.fields[i];
                if ($.inArray(field.name, forbidFields) != -1)
                    config.Form.fields.splice(i, 1);
            }
        }
        if (config.Grid && config.Grid.columns) {
            for (var i = config.Grid.columns.length - 1; i >= 0; i--) {
                var column = config.Grid.columns[i];
                if ($.inArray(column.name, forbidFields) != -1)
                    config.Grid.columns.splice(i, 1);
            }
        }
        if (config.Search && config.Search.fields) {
            for (var i = config.Search.fields.length - 1; i >= 0; i--) {
                var field = config.Search.fields[i];
                if ($.inArray(field.name, forbidFields) != -1)
                    config.Search.fields.splice(i, 1);
            }
        }
    };

    //查找是否存在某一个按钮
    iTools.findToolbarItem = function (grid, itemID) {
        if (!grid.toolbarManager) return null;
        if (!grid.toolbarManager.options.items) return null;
        var items = grid.toolbarManager.options.items;
        for (var i = 0, l = items.length; i < l; i++) {
            if (items[i].id == itemID) return items[i];
        }
        return null;
    }


    //设置grid的双击事件(带权限控制)
    iTools.setGridDoubleClick = function (grid, btnID, btnItemClick) {
        btnItemClick = btnItemClick || toolbarBtnItemClick;
        if (!btnItemClick) return;
        grid.bind('dblClickRow', function (rowdata) {
            var item = iTools.findToolbarItem(grid, btnID);
            if (!item) return;
            grid.select(rowdata);
            btnItemClick(item);
        });
    }


})(jQuery);
