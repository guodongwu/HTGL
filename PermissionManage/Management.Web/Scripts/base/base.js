/// <reference path="../jquery-1.5.1.js" />

(function ($) {
    var dtd = $.Deferred(); // 新建一个Deferred对象
    //全局变量
    window["_base"] = {
        //var _this=this;
        add: function (options) {
            var _options = $.extend({}, options);
            //url链接
            //if (!_options.url) _options.url = "Add";
            if (_options.dom && _options.url) {
                $.get(_options.url, function (data) {
                    $(_options.dom).html(data);
                });
            }
            //title标题
            if (!_options.title) _options.title = "添加";
            if (!_options.saveurl) _options.saveurl = "Add";
            //buttons按钮
            if (!_options.buttons) {
                _options.buttons =
                    [{ text: '确定', onclick: function (item, dialog) { _base.addsave(_options.dom, _options.saveurl) } },
                    { text: '取消', onclick: function (item, dialog) { dialog.hide(); } }]
            }

            if (_options.dom) {
                _options.target = $(_options.dom);
                _options.url = undefined;
            }

            $.ligerDialog.open(_options);
        },
        addsave: function (dialog, saveurl) {
            var entity = _base.getFields(dialog);
            //alert($.toJSON(entity));
            $.ajax({
                url: saveurl,
                data: entity,
                type: 'json',
                success: function () {
                    iTools.showSuccess('添加成功！');
                    f_reload();
                },
                error: function (message) {
                    iTools.showError(message);
                }
            });
        },
        getFields: function (target) {

            var entity = {};
            if (target == undefined)
                target = this._container;

            var allfileds = $("[field]", target);
            allfileds.each(function (i) {
                var element = $(this);
                var key = element.attr("field");
                var tokens = key.toString().split('.');


                var tokevalue = function (v) {
                    ///	<summary>
                    ///	实体赋值
                    ///	</summary>
                    if (tokens != undefined && tokens.length && tokens.length > 1) {
                        if (entity[tokens[0]] == undefined)
                            entity[tokens[0]] = {};
                        entity[tokens[0]][tokens[1]] = v;
                    }
                    else {
                        entity[key] = v;
                    }
                };
                //根据元素不同做不同处理
                if (element.attr("type") == "radio") {
                    $("[name='" + element.attr("name") + "']", target).each(function () {
                        var r = $(this);
                        if (r.attr("checked")) {
                            tokevalue(r.val());
                        }
                    });
                } else if (element.attr("type") == "checkbox") {
                    var last = [];
                    $("[name='" + element.attr("name") + "']", target).each(function () {
                        var r = $(this);
                        if (r.attr("checked")) {
                            last.push(r.val());
                        }
                    });
                    tokevalue(last);
                }
                else {
                    tokevalue($(this).val());
                }
            });
            return entity;
        },
        update: function (options, entity) {
            var _options = $.extend({}, options);
            //url链接
            //if (!_options.url) _options.url = "Update";
            if (_options.dom && _options.url) {
                $.get(_options.url, function (data) {
                    $(_options.dom).html(data);
                    //_base.setFields(entity, $(_options.dom));
                });
            }
            //title标题
            if (!_options.title) _options.title = "修改";
            if (!_options.saveurl) _options.saveurl = "Update";
            //buttons按钮
            if (!_options.buttons) {
                _options.buttons =
                    [
                    { text: '确定', onclick: function (item, dialog) { _base.updatesave(_options.dom, _options.saveurl) } },
                    { text: '取消', onclick: function (item, dialog) { dialog.hide(); } }]
            }

            if (_options.dom) {
                _options.target = $(_options.dom);
                _options.url = undefined;
            }

            $.ligerDialog.open(_options);
            //$.when(_base.dialogOpen(_options, dtd)).done(function () {

            //    //alert("over");
            //});
        },
        updatesave: function (dialog, saveurl) {
            var entity = _base.getFields(dialog);
            //alert($.toJSON(entity));
            $.ajax({
                url: saveurl,
                data: entity,
                type: 'json',
                success: function () {
                    iTools.showSuccess('保存成功！');
                    f_reload();
                },
                error: function (message) {
                    iTools.showError(message);
                }
            });
        },
        setFields: function (entity, target) {
            if (entity == undefined)
                return;
            if (target == undefined)
                target = this._container;
            var allfileds = $("[field]", target);

            //alert($.toJSON(entity));
            allfileds.each(function (i) {
                var element = $(this);
                var key = element.attr("field");

                var tokens = key.toString().split('.');
                var val;
                if (tokens != undefined && tokens.length && tokens.length > 1) {
                    var ent = entity[tokens[0]];
                    if (ent != undefined)
                        val = ent[tokens[1]];
                }
                else {
                    val = entity[key];
                }

                if (val != undefined) {
                    if (element.attr("type") == "radio") {
                        $("[name='" + element.attr("name") + "']", target).each(function () {
                            if ($(this).val() == val)
                                $(this).prop("checked", true);
                            else
                                $(this).prop("checked", false);
                        });
                    } else if (element.attr("type") == "checkbox") {
                        $.each(val, function (index) {
                            var thatelemetn = $("[name='" + element.attr("name") + "'][value='" + val[index] + "']", target);
                            thatelemetn.prop("checked", true);
                        });
                    }
                    else if (!(element.is('input') || element.is('textarea') || element.is('select'))) {
                        element.text(val);
                    }
                    else {
                        element.val(val);
                    }
                }

                //var ele = $("[name=" + key + "]", mainform);
                ////针对复选框和单选框 处理
                //if (ele.is(":checkbox,:radio")) {
                //    ele[0].checked = val[key] ? true : false;
                //}
            });

            //下面是更新表单的样式
            var managers = $.ligerui.find($.ligerui.controls.Input);
            for (var i = 0, l = managers.length; i < l; i++) {
                //改变了表单的值，需要调用这个方法来更新ligerui样式
                var o = managers[i];
                o.updateStyle();
                if (managers[i] instanceof $.ligerui.controls.TextBox)
                    o.checkValue();
            }
        },
        dialogOpen: function (_options, dtd) {
            $.ligerDialog.open(_options);
            dtd.resolve();
            return dtd;
        },
        progressNullValue: function (data) {
            for (var i in data) {
                if (!data[i] || data[i] == null)
                    data[i] = "";
            }
            return data;
        }
    };
})(jQuery);
