var editRow = undefined; //定义全局变量：当前编辑的行

var colExpandModels = [];//扩展字段

$(function () {
    var id = $("#Id").val();
    var operation = $("#operation").val();

    initSelect();
    if ("add" != operation) {
        //加载form
        $.ajax({
            url: "/Bid/BidNotice/GetFormJson",
            data: { keyValue: id },
            dataType: "json",
            async: false,
            success: function (data) {
                $("#form1").formSerialize(data);
            }
        });
    }
    
    gridList_menu();//招标清单
    gridList_suplist();//邀标供应商
    gridList_splist();//审批资料
    gridList_bslist();//标书文件
    gridList_tblist();//投标文件

    initControl();//初始化表单向导
    initUpLoad();//初始化上传组件
    validateRule();//校验规格
})


//初始化下拉框
function initSelect() {
    //采购类别
    $("#PurType").bindSelect({
        url: "/SysManage/ItemsDetail/GetSelectJson",
        id: "text",
        param: { Code: "CG" },
        change: function (data)
        {
            //获取对应类型的扩展字段
            $.get('/SysCommon/BDConfig/GetGridJson?bidType=竞价&itemId=' + data.id + '&keyword=', function (msg) {
                for (var i = 0; i < msg.length; i++)
                {
                    var tempCol = {};
                    tempCol.label = msg[i].ExpandColumnTitle;
                    tempCol.name = msg[i].ExpandColumn;
                    tempCol.width = msg[i].ColumnWidth == "" ? '80px' : msg[i].ColumnWidth + 'px';
                    colExpandModels.push(tempCol);
                }
                
            }, "json");
        }

    });
    //竞价模式
    $("#BidModel").bindSelect({
        url: "/SysManage/ItemsDetail/GetSelectJson",
        id: "text",
        param: { Code: "BIDM" }
    });

    //报价模式
    $("#QuoteType").bindSelect({
        url: "/SysManage/ItemsDetail/GetSelectJson",
        id: "text",
        param: { Code: "BM" }
    });
    //降价模式
    $("#ReduceType").bindSelect({
        url: "/SysManage/ItemsDetail/GetSelectJson",
        id: "text",
        param: { Code: "JM" }
    });
    $("#ReduceType").on("change", function (e) {
        reduceTypeShow();
    });
}

//控制降价模式的显示
function reduceTypeShow() {
    var reduceType = $("#ReduceType").val();
    if (reduceType == "固定额度模式") {
        $("#reduce_value").show();
        $("#reduce_value_section").hide();
        $("#reduce_percent").hide();
        $("#reduce_percent_section").hide();
    }
    if (reduceType == "区间额度模式") {
        $("#reduce_value").hide();
        $("#reduce_value_section").show();
        $("#reduce_percent").hide();
        $("#reduce_percent_section").hide();
    }
    if (reduceType == "固定百分比模式") {
        $("#reduce_value").hide();
        $("#reduce_value_section").hide();
        $("#reduce_percent").show();
        $("#reduce_percent_section").hide();
    }
    if (reduceType == "区间百分比模式") {
        $("#reduce_value").hide();
        $("#reduce_value_section").hide();
        $("#reduce_percent").hide();
        $("#reduce_percent_section").show();
    }
    if (reduceType == "无限制") {
        $("#reduce_value").hide();
        $("#reduce_value_section").hide();
        $("#reduce_percent").hide();
        $("#reduce_percent_section").hide();
    }
}

//绑定字典内容到指定的Select控件
function BindSelect(ctrlName, url) {
    var control = $('#' + ctrlName);
    //设置Select2的处理
    control.select2({
        allowClear: true,
        placeholder: "请选择",
        formatResult: function (item) { },//结果回调
        formatSelection: function (item) { },//选中回调
        escapeMarkup: function (m) {
            return m;
        }
    });

    //绑定Ajax的内容
    $.getJSON(url, function (data) {
        //control.empty();//清空下拉框
        $.each(data.rows, function (i, item) {
            control.append("<option value='" + item.text + "'>&nbsp;" + item.text + "</option>");
        });
    });
}

//绑定字典内容到指定的Select控件
function BindSelect2(ctrlName, url) {
    //绑定Ajax的内容
    $.getJSON(url, function (data) {
        $('#' + ctrlName).select2({
            data: data.rows,
            placeholder: '请选择',
            allowClear: true,
            templateResult: function (item) {
                return item.text;
            },
            formatResult: function (item) {
                return item.text;
            },
        })
    });
}

//初始化表单向导
function initControl() {
    $('#wizard').wizard().on('change', function (e, data) {
        var $finish = $("#btn_finish");
        var $next = $("#btn_next");
        if (data.direction == "next") {
            switch (data.step) {
                case 1://step1:校验基本信息
                    if (!setp1_validate()) {
                        return false;
                    }
                    //$("#tt_req").gridUnload("#tt_req");
                    $.jgrid.gridUnload("#tt_req");
                    gridList_menu();//招标清单
                    break;
                case 2://招标清单校验
                    var ids = $("#tt_req").jqGrid('getDataIDs');
                    if (ids.length > 0) {
                        return true;
                    } else {
                        $.modalAlert("招标需求清单不能为空！", "error");
                        return false;
                    }
                    break;
                case 3://邀标清单校验
                    var bidtype = $("input[name='BIDTYPE']:checked").val();
                    if ("邀请招标" == bidtype || "邀请加公开" == bidtype) {
                        var ids = $("#tt_sup").jqGrid('getDataIDs');
                        if (ids.length > 0) {
                            return true;
                        } else {
                            $.modalAlert("该招标类型为《" + bidtype + "》，邀标供应商列表不能为空！", "error");
                            return false;
                        }
                    } else {
                        return true;
                    }
                    break;
                case 4://step4:校验公告设定信息
                    if (!setp4_validate()) {
                        return false;
                    }
                    break;
                case 5:
                    break;
                case 6:
                    $finish.show();
                    $next.hide();
                    return true;
                    break;
                default:
                    break;
            }
        } else {
            $finish.hide();
            $next.show();
        }
    });
}

//校验规格
function validateRule() {
    $("#form1").validate({
        debug: true,
        onkeyup: true,
        focusInvalid: true,
        rules: {
            ProjectNo: "required",
            ProjectName: {
                required: true
            },
            ProjectMan: {
                required: true
            },
            ProjectManTel: {
                required: true,
                isPhone: true
            },
            ProjectManMail: {
                required: true,
                email: true
            }
        },
        messages: {
            ProjectNo: "项目编号不能为空",
            ProjectName: {
                required: "请输入项目名称"
            },
            ProjectMan: {
                required: "请输入项目联系人"
            },
            ProjectManTel: {
                required: "请输入项目联系人电话"
            },
            ProjectManMail: {
                required: "请输入Email地址",
                email: "请输入正确的email地址"
            }
        },
        errorPlacement: function (error, element) {
            element.parents('.formValue').addClass('has-error');
            element.parents('.has-error').find('i.error').remove();
            element.parents('.has-error').append('<i class="form-control-feedback fa fa-exclamation-circle error" data-placement="left" data-toggle="tooltip" title="' + error + '"></i>');
            $("[data-toggle='tooltip']").tooltip();
            if (element.parents('.input-group').hasClass('input-group')) {
                element.parents('.has-error').find('i.error').css('right', '33px')
            }
        },
        success: function (element) {
            element.parents('.has-error').find('i.error').remove();
            element.parent().removeClass('has-error');
        }
    });
}

//setp1:公告基本校验
function setp1_validate() {
    var result = true;
    result = result & $("#form1").validate().element($("#ProjectNo"))
            & $("#form1").validate().element($("#ProjectName"))
            & $("#form1").validate().element($("#ProjectMan"))
            & $("#form1").validate().element($("#ProjectManTel"))
            & $("#form1").validate().element($("#ProjectManMail"))
            & $("#form1").validate().element($("#RepBegindate"))
            & $("#form1").validate().element($("#RepEndDate"))
            //& $("#form1").validate().element($("#BIDREADBEGIN"))
            & $("#form1").validate().element($("#BidBeginDate"))
            & $("#form1").validate().element($("#BidEndDate"));

    var purType = $("#PurType").val();
    if ("" == purType || "&nbsp;" == purType) {
        valid_error("采购类别不能为空！", $("#PurType"));
        result = result & false;
    } else {
        valid_success($("#PurType"));
    }
    return result;
}

//setp4:公告设定信息校验
function setp4_validate() {
    var result = true;
    var valType = $("input[name='AwardType']:checked").val();
    if ("专家决标" == valType) {
        result = result & $("#form1").validate().element($("#EvaBeginDate"))
                 & $("#form1").validate().element($("#EvaEndDate"));
    }
    var reduceType = $("#ReduceType").val();
    if (reduceType == "固定额度模式") {
        result = result & $("#form1").validate().element($("#ReduceValue"));
    }
    if (reduceType == "区间额度模式") {
        result = result & $("#form1").validate().element($("#MinReduce"))
                & $("#form1").validate().element($("#MaxReduce"));
    }
    if (reduceType == "固定百分比模式") {
        result = result & $("#form1").validate().element($("#ReducePer"));
    }
    if (reduceType == "区间百分比模式") {
        result = result & $("#form1").validate().element($("#MinReducePer"))
                & $("#form1").validate().element($("#MaxReducePer"));
    }
    var bidTimes = $("input[name='QuoteLimit']:checked").val();
    if (bidTimes == "是") {//报价次数
        result = result & $("#form1").validate().element($("#QuoteNum"));
    }

    var ifBidPrice = $("input[name='UpperLimit']:checked").val();
    if (ifBidPrice == "是") {//标底价
        result = result & $("#form1").validate().element($("#UpperPrice"));
    }

    var bjType = $("#QuoteType").val();

    if ("" == reduceType || "&nbsp;" == reduceType) {
        valid_error("降价模式不能为空！", $("#QuoteType"));
        result = result & false;
    } else {
        valid_success($("#ReduceType"));
    }
    if ("" == bjType || "&nbsp;" == bjType) {
        valid_error("报价模式不能为空！", $("#ReduceType"));
        result = result & false;
    } else {
        if ("单价决标" == valType) {
            if ("报单价" != bjType) {
                valid_error("当前项目的决标方式为《单价决标》，报价模式只能选择《报单价》，请修改！", $("#QUOTETYPE"));
                result = result & false;
            } else {
                valid_success($("#QuoteType"));
            }
        } else {
            valid_success($("#QuoteType"));
        }

    }
    var bidM = $("#BidModel").val();
    if ("" == bidM || "&nbsp;" == bidM) {
        valid_error("竞价模式不能为空！", $("#BidModel"));
        result = result & false;
    } else
    {
        valid_success($("#BidModel"));
    }
    result = result & $("#form1").validate().element($("#TimeoutInterval"));
    result = result & $("#form1").validate().element($("#DelayEndDate"));
    return result;
}

//初始化上传组件
function initUpLoad() {  
    //标的上传
    $('#uploadify_bd').uploadifive({
        //'swf': '/Content/js/uploadify/uploadify.swf',  //FLash文件路径
        'buttonText': '浏览文件',                                 //按钮文本
        'uploadScript': '/SysCommon/Common/Upload_bd_Excel?name=Bid_Aff_Sub&bindid=' + $("#Id").val(),                       //处理文件上传Action
        'queueID': 'fileQueue_bd',                        //队列的ID
        'queueSizeLimit': 10,                          //队列最多可上传文件数量，默认为999
        'auto': false,                                 //选择文件后是否自动上传，默认为true
        'multi': false,                                 //是否为多选，默认为true
        'removeCompleted': true,                       //是否完成后移除序列，默认为true
        'fileSizeLimit': '10MB',                       //单个文件大小，0为无限制，可接受KB,MB,GB等单位的字符串值
        'fileTypeDesc': '支持格式:xls.',               //文件描述
        'fileTypeExts': '*.xls; *.xlsx;',              //上传的文件后缀过滤器
        'onQueueComplete': function (event, data) {    //所有队列完成后事件
            // $.modalAlert("加载完毕！", "success");//提示完成
        },
        'onUploadStart': function (file) {
        },
        //上传完成后执行
        'onUploadComplete': function (file, data) {
            var result = JSON.parse(data);
            if ('T' == result.status) {
                $("#tt_req").trigger("reloadGrid");
                $("#bdModal").modal('hide');
            } else {
                $.modalAlert(result.msg, "error");
            }
        },
        'onError': function (errorType) {
            alert('发生错误: ' + errorType);
        },
        'onFallback': function () {
            alert('该浏览器无法使用,请选择支持HTML5的浏览器！');
        }
    });
}

//需求清单
function gridList_menu() {
    var bidtype = $("#PurType").val();
    colModels = [
            { name: 'Id', label: '主键', hidden: true, key: true },
            { name: 'OrderUnit', label: '订货单位', width: '150px' },
            { name: 'Number', label: '物料编号', width: '150px' },
            { name: 'Name', label: '项目名称', width: '200px' },             
            { name: 'Specification', label: '物料规格', width: '150px' },
			{ name: 'DES', label: '物料描述', width: '150px' },
            { name: 'Brand', label: '牌号', width: '100' },
			{ name: 'Quantity', label: '数量', width: '100px' },
			{ name: 'Unit', label: '单位', width: '80px' },
            { name: 'DeliveryPlace', label: '交货地', width: '80px' },
            { name: 'DeliveryDate', label: '交货日期', width: '80px' }
    ];

    for (var i = 0; i < colExpandModels.length; i++)
    {
        colModels.push(colExpandModels[i]);
    }

    var hispriceCol = {
        label: '标底价',
        name: 'HISPRICE',
        width: '80px'
    };
    colModels.push(hispriceCol);

    var remarkCol = {
        label: '备注',
        name: 'REMARK',
        width: '200px'
    };
    colModels.push(remarkCol);

    var id = $("#Id").val();
    var $gridList = $("#tt_req");

    $gridList.dataGrid({
        url: '/Bid/BidNotice/GetSubList?bindid=' + id,
        height: 260,
        rowNum: -1,
        width: ($(window).width() - 200) + 'px',
        colModel: colModels,
        sortname: 'Id desc',
        shrinkToFit: false,
        viewrecords: true
    });
    $gridList.setGridWidth($(window).width() - 100);
}

function gridList_menu_1() {
    var id = $("#Id").val();
    var $gridList = $("#tt_req");
    $gridList.dataGrid({
        url: '/Bid/BidNotice/GetSubList?bindid=' + id,
        height: 200,
        colModel: [
            { label: '主键', name: 'ID', hidden: true, key: true },
            { name: 'NUMBER', label: '编号', width: '150px' },
			{ name: 'DES', label: '描述', width: '200px' },
			{ name: 'SPECIFICATION', label: '规格', width: '150px' },
			{ name: 'QUANTITY', label: '数量', width: '100px' },
			{ name: 'UNIT', label: '单位', width: '80px' },
			{ name: 'REMARK', label: '备注', width: '200px' }
        ],
        sortname: 'ID desc',
        viewrecords: true
    });
}

//供应商
function gridList_suplist() {

    var id = $("#Id").val();
    var $gridList = $("#tt_sup");
    $gridList.dataGrid({
        url: '/Bid/BidNotice/GetSupGridJson?bindid=' + id,
        height: 200,
        colModel: [
            { label: '主键', name: 'Id', hidden: true, key: true },
            { name: 'SupNo', label: '用户名', width: '100px' },
			{ name: 'SupName', label: '供应商名称', width: '150px' },
			{ name: 'LinkMan', label: '联系人', width: '150px' },
			{ name: 'TelPhone', label: '电话', width: '200px' },
			{ name: 'MailBox', label: '邮箱', width: '150px' },
			{ name: 'Address', label: '地址', width: '300px' }
        ],
        sortname: 'CreateDate desc',
        viewrecords: true
    });
    $gridList.setGridWidth($(window).width() - 100);
}

//审批资料
function gridList_splist() {
    var id = $("#Id").val();
    var $gridList = $("#tt_sp");
    $gridList.dataGrid({
        url: '/Bid/BidNotice/GetApprovalGridJson?bindid=' + id,
        height: 200,
        colModel: [
            { label: '主键', name: 'Id', hidden: true, key: true },
            { name: 'FileName', label: '名称', width: '300px', editor: 'textbox' },
			{ name: 'FileDes', label: '描述', width: '300px', editor: 'textbox' },
			{
			    name: 'FileURL', label: '附件', width: '350px', editor: 'textbox',
			    formatter: function (cellvalue, options, rowObject) {
			        if (cellvalue != "&nbsp;" && cellvalue != null) {
			            return '<a style=\'color:blue;\' href=\'' + cellvalue + '\'>' + rowObject.FileName + '</a>';
			        } else {
			            return cellvalue;
			        }
			    }
			}
        ],
        sortname: 'CreateDate desc',
        viewrecords: true
    });
    $gridList.setGridWidth($(window).width() - 100);
}

//标书文件
function gridList_bslist() {
    var id = $("#Id").val();
    var $gridList = $("#tt_bs");
    $gridList.dataGrid({
        url: '/Bid/BidNotice/GetBidGridJson?bindid=' + id,
        height: 200,
        colModel: [
            { label: '主键', name: 'Id', hidden: true, key: true },
			{ name: 'FileName', label: '标题', width: '200px' },
			{ name: 'FileDes', label: '说明', width: '300px' },
			{
			    name: 'FileURL', label: '附件', width: '300px',
			    formatter: function (cellvalue, options, rowObject) {
			        if (cellvalue != "&nbsp;" && cellvalue != null) {
			            return '<a style=\'color:blue;\' href=\'' + cellvalue + '\'>' + rowObject.FileName + '</a>';
			        } else {
			            return cellvalue;
			        }
			    }
			}
        ],
        sortname: 'CreateDate desc',
        viewrecords: true
    });
    $gridList.setGridWidth($(window).width() - 100);
}

//投标文件
function gridList_tblist() {

    var id = $("#Id").val();
    var $gridList = $("#tt_tb");
    $gridList.dataGrid({
        url: '/Bid/BidNotice/GetRespondGridJson?bindid=' + id,
        height: 200,
        colModel: [
            { label: '主键', name: 'Id', hidden: true, key: true },
			{ name: 'FileName', label: '标题', width: '200' },
			{ name: 'FileDes', label: '说明', width: '300' }
        ],
        sortname: 'CreateDate desc',
        viewrecords: true
    });

    $gridList.setGridWidth($(window).width() - 100);
}


//添加修改物料
function addreq() {
    var bindid = $("#Id").val();
    $.modalOpen({
        id: "SubForm",
        title: "新增物料",
        url: "/Bid/BidNotice/SubForm?BindId=" + bindid,
        width: "450px",
        height: "400px",
        callBack: function (iframeId) {
            top.frames[iframeId].submitForm();
        }
    });
}

//上传标的
function importreq() {
    $("#bdModal").modal('show');
}


//删除物料
function delreq() {
    var keyValue = $("#tt_req").jqGridRowValue().Id;
    if ($.checkedArray(keyValue)) {
        $.deleteForm({
            url: "/Bid/BidNotice/DeleteNoticeSub",
            param: { keyValue: $("#tt_req").jqGridRowValue().Id },
            success: function () {
                $.currentWindow().$("#tt_req").trigger("reloadGrid");
            }
        });
    }
}
//刷新物料
function refreshreq() {
    $("#tt_req").trigger("reloadGrid");
}



//选择供应商
function choosesup() {
    $.modalOpen({
        id: "SupForm",
        title: "选择供应商",
        url: "/Supplier/SupplierBase/ChooseSupplier?isSingle=0&Category=" + $("#PurType").val(),
        width: "700px",
        height: "600px",
        callBack: function (iframeId) {
            top.frames[iframeId].chooseSupConfirm();
        }
    });
}

//选择供应商--确定
function dealSelectedSup(datalist) {

    var keyValue = $("#Id").val();
    if (datalist.length > 0) {
        var list = [];
        for (var i in datalist) {
            var rows = $("#tt_sup").jqGrid("getRowData");
            var rowFlag = false;
            for (var j in rows) {
                if (rows[j].SUPNO == datalist[i].SUPNO) {
                    rowFlag = true;
                    break;
                }
            }
            if (!rowFlag) {
                var newrow = {};
                newrow.Id = $.fn.guid();
                newrow.BindId = keyValue;
                newrow.SupNo = datalist[i].SupNo;
                newrow.SupName = datalist[i].SupName;
                newrow.LinkMan = datalist[i].Name;
                newrow.TelPhone = datalist[i].Mobile;
                newrow.MailBox = datalist[i].Email;
                newrow.Address = datalist[i].Area + datalist[i].Area1 + datalist[i].Area2 + datalist[i].Area3;

                list.push(newrow);
            }
        }

        if (list.length > 0) {
            para = {};
            para.supList = list;
            para = mvcParamMatch(para);
            $.submitForm({
                url: "/Bid/BidNotice/SaveNoticeSupList?keyValue=" + keyValue,
                param: para,
                success: function () {
                    freshsup();
                }
            })
        }
    }
    else {
        $.modalAlert("请选择需要添加的数据", "warning");
    }
}

//删除供应商
function delsup() {
    var keyValue = $("#tt_sup").jqGridRowValue().Id;
    if ($.checkedArray(keyValue)) {
        $.deleteForm({
            url: "/Bid/BidNotice/DeleteNoticeSup",
            param: { keyValue: $("#tt_sup").jqGridRowValue().Id },
            success: function () {
                $.currentWindow().$("#tt_sup").trigger("reloadGrid");
            }
        });
    }
}
//刷新供应商
function freshsup() {
    $("#tt_sup").trigger("reloadGrid");
}

//添加审批、标书文件
function addFile(title,flag)
{
    var id = $("#Id").val();
    $.modalOpen({
        id: "fileForm",
        title: "新增" + title,
        url: "/Bid/BidNotice/FileForm?BindId=" + id + "&flag=" + flag,
        width: "600px",
        height: "500px",
        callBack: function (iframeId) {
            top.frames[iframeId].submitForm();
        }
    });
}
//删除审批
function delsp() {
    var keyValue = $("#tt_sp").jqGridRowValue().Id;
    if ($.checkedArray(keyValue)) {
        $.deleteForm({
            url: "/Bid/BidNotice/DeleteNoticeFileApproval",
            param: { keyValue: $("#tt_sp").jqGridRowValue().Id },
            success: function () {
                $.currentWindow().$("#tt_sp").trigger("reloadGrid");
            }
        });
    }
}
//刷新审批
function refreshsp() {
    $("#tt_sp").trigger("reloadGrid");
}

//删除标书
function delbs() {
    var keyValue = $("#tt_bs").jqGridRowValue().Id;
    if ($.checkedArray(keyValue)) {
        $.deleteForm({
            url: "/Bid/BidNotice/DeleteNoticeFileBid",
            param: { keyValue: $("#tt_bs").jqGridRowValue().Id },
            success: function () {
                $.currentWindow().$("#tt_bs").trigger("reloadGrid");
            }
        });
    }
}
//刷新标书
function freshbs() {
    $("#tt_bs").trigger("reloadGrid");
}

//添加投标
function addtb() {
    $("#tbModal").modal('show');
}
//确定添加修改投标文件
function tb_comfirm() {
    $("#BindId").val($("#Id").val());
    if ($('#form5').formValid()) {
        var postData = $("#form5").formSerialize();
        $.submitForm({
            url: "/Bid/BidNotice/SaveNoticeFileRespond?keyValue=",
            param: postData,
            success: function () {
                $.currentWindow().freshtb();
            }
        });

    }
}
//删除投标文件
function deltb() {
    var keyValue = $("#tt_tb").jqGridRowValue().Id;
    if ($.checkedArray(keyValue)) {
        $.deleteForm({
            url: "/Bid/BidNotice/DeleteNoticeFileRespond",
            param: { keyValue: $("#tt_tb").jqGridRowValue().Id },
            success: function () {
                $.currentWindow().$("#tt_tb").trigger("reloadGrid");
            }
        });
    }        
}

//刷新投标文件
function freshtb() {
    $("#tt_tb").trigger("reloadGrid");
}

//暂存公告
function saveNotice() {
    var keyValue = $("#Id").val();
    $.submitForm({
        url: "/Bid/BidNotice/SaveForm?keyValue=" + keyValue,
        param: $("#form1").formSerialize(),
        success: function () {
            $.modalAlert("操作成功！", "success");
        }
    });
}
//发布公告
function publishNotice() {
    // if ($('#form1').formValid()) {
    if (validateForm()) {
        if (validateList()) {
            var ids = $("#tt_bs").jqGrid('getDataIDs');
            if (ids.length > 0) {
                var ids = $("#tt_tb").jqGrid('getDataIDs');
                if (ids.length > 0) {
                    postNotice();
                } else {
                    $.modalConfirm("投标文件列表为空，确定不添加投标文件吗？", function del_expert(flag) {
                        if (flag) {
                            postNotice();
                        }
                    });
                }
            } else {
                $.modalConfirm("标书文件列表为空，确定不上传标书文件吗？", function bs_confirm(flag) {
                    if (flag) {
                        var ids = $("#tt_tb").jqGrid('getDataIDs');
                        if (ids.length > 0) {
                            postNotice();
                        } else {
                            $.modalConfirm("投标文件列表为空，确定不添加投标文件吗？", function tb_confirm(flag) {
                                if (flag) {
                                    postNotice();

                                }
                            });
                        }
                    }
                });
            }
        }
    } else {
        $.modalAlert("未通过数据有效性校验，请检查数据", "error");
    }
}

function postNotice() {
    var keyValue = $("#Id").val();
    $.submitForm({
        url: "/Bid/BidNotice/PublishForm?keyValue=" + keyValue,
        param: $("#form1").formSerialize(),
        success: function () {
            var parentTabId = top.$.jfinetab.getCurrentTabParentId();
            var resultPage = top.$.jfinetab.getTabContentFromId(parentTabId);
            resultPage.refreshGrid();
            top.$.jfinetab.closeCurrentTab();
        }
    });
}

//取消公告
function cancelNotice() {
    $.modalConfirm("确定要取消该项目吗？", function del_expert(flag) {
        if (flag) {
            var projectId = $("#Id").val();
            $.post('/Bid/BidNotice/DeleteForm?keyValue=' + projectId, function (msg) {
                var result = JSON.parse(msg);
                if ("success" == result.state) {
                    $.modalAlert("操作成功！", "success");
                    top.$.jfinetab.closeCurrentTab();
                } else {
                    $.modalAlert("操作失败，请重新操作！", "error");
                }
            });
        }
    });
}

//关闭公告
function closeNotice() {
    top.$.jfinetab.closeCurrentTab();
}

//对form进行校验
function validateForm() {
    var result = true;
    var ifBidPrice = $("input[name='UpperLimit']:checked").val();
    if (ifBidPrice == "是") {//标底价
        result = result & $("#form1").validate().element($("#UpperPrice"));
    }
    var bidTimes = $("input[name='QuoteLimit']:checked").val();
    if (bidTimes == "是") {//报价次数
        result = result & $("#form1").validate().element($("#QuoteNum"));
    }
    var valType = $("input[name='AwardType']:checked").val();
    if ("专家决标" == valType) {
        result = result & $("#form1").validate().element($("#EvaBeginDate"))
                 & $("#form1").validate().element($("#EvaEndDate"));
    }
    var reduceType = $("#ReduceType").val();
    if (reduceType == "固定额度模式") {
        result = result & $("#form1").validate().element($("#ReduceValue"));
    }
    if (reduceType == "区间额度模式") {
        result = result & $("#form1").validate().element($("#MinReduce"))
                & $("#form1").validate().element($("#MaxReduce"));
    }
    if (reduceType == "固定百分比模式") {
        result = result & $("#form1").validate().element($("#ReducePer"));
    }
    if (reduceType == "区间百分比模式") {
        result = result & $("#form1").validate().element($("#MinReducePer"))
                & $("#form1").validate().element($("#MaxReducePer"));
    }
    result = result & $("#form1").validate().element($("#ProjectNo"))
            & $("#form1").validate().element($("#ProjectName"))
            & $("#form1").validate().element($("#ProjectMan"))
            & $("#form1").validate().element($("#ProjectManTel"))
            & $("#form1").validate().element($("#ProjectManMail"))
            & $("#form1").validate().element($("#RepBegindate"))
            & $("#form1").validate().element($("#RepEndDate"))
            & $("#form1").validate().element($("#BidBeginDate"))
            & $("#form1").validate().element($("#BidEndDate"))
            & $("#form1").validate().element($("#QuoteType"))
            & $("#form1").validate().element($("#ReduceType"));

    var bjType = $("#QuoteType").val();

    if ("" == reduceType || "&nbsp;" == reduceType) {
        valid_error("降价模式不能为空！", $("#ReduceType"));
        result = result & false;
    } else {
        valid_success($("#ReduceType"));
    }
    if ("" == bjType || "&nbsp;" == bjType) {
        valid_error("报价模式不能为空！", $("#QuoteType"));
        result = result & false;
    } else {
        if ("单价决标" == valType) {
            if ("报单价" != bjType) {
                valid_error("当前项目的决标方式为《单价决标》，报价模式只能选择《报单价》，请修改！", $("#QuoteType"));
                result = result & false;
            } else {
                valid_success($("#QuoteType"));
            }
        } else {
            valid_success($("#QuoteType"));
        }

    }
    return result;
}

//对列表进行校验
function validateList() {
    //标的验证
    var ids_req = $("#tt_req").jqGrid('getDataIDs');
    if (ids_req.length <= 0) {
        $.modalAlert("招标需求清单不能为空！", "error");
        return false;
    }
    //邀标供应商验证
    var bidtype = $("input[name='BidType']:checked").val();
    if ("邀请招标" == bidtype || "邀请加公开" == bidtype) {
        var ids = $("#tt_sup").jqGrid('getDataIDs');
        if (ids.length <= 0) {
            $.modalAlert("该招标类型为《" + bidtype + "》，邀标供应商列表不能为空！", "error");
            return false;
        }
    }

    return true;


}

//下载标的导入模板
function downloadreq() {
    colNames = $("#tt_req").jqGrid('getGridParam', 'colNames')
    colModel = $("#tt_req").jqGrid('getGridParam', 'colModel')
    var data = {};
    for (i = 0; i < colNames.length; i++) {
        var columnHidden = colModel[i].hidden;
        var columnName = colModel[i].name;
        if (columnHidden == false && columnName != "rn") {
            data[columnName] = colNames[i];
        }

    }
    filename = '(' + $("#ProjectNo").val() + ')标的上传模板';
    head = JSON.stringify(data);
    $("#filename").val(filename);
    $("#head").val(head);
    $("#download_form").attr("action", "/SysCommon/Common/downloadExcelModule");
    $("#download_form").submit();
}

function valid_error(error, element) {
    element.parents('.formValue').addClass('has-error');
    element.parents('.has-error').find('i.error').remove();
    element.parents('.has-error').append('<i class="form-control-feedback fa fa-exclamation-circle error" data-placement="left" data-toggle="tooltip" title="' + error + '"></i>');
    $("[data-toggle='tooltip']").tooltip();
    if (element.parents('.input-group').hasClass('input-group')) {
        element.parents('.has-error').find('i.error').css('right', '33px')
    }
}

function valid_success(element) {
    element.parents('.has-error').find('i.error').remove();
    element.parent().removeClass('has-error');
}