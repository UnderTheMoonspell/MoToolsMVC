﻿(function () {
    'use strict'
    var MenuController = {
        initialWidth: "243px",
        minimizedWidth: "36px",
        menuControllerUrl: $('#IMG_Hamburger_Menu').attr('data-src'),

        init: function () {
            
            $('.group-expand>a').on('click', function () {
                $(this).siblings('ul').children('.group-expand').slideToggle('fast', function(){
                    $(this).toggleClass('group-hide');
                })
            })

            $('#IMG_Hamburger_Menu').on('click', function () {
                MenuController.HamburgerClicked();
            });

            //Esta parte é para corrigir um problema que havia quando o Menu começa colapsado. Podia ser feito no razor tambem
            if (MenuController.IsMenuOpen()) {
                $("#menuInitialContent , #TD_MenuArea").css('width', MenuController.initialWidth);
            }
            else {
                $("#menuInitialContent , #TD_MenuArea").css('width', MenuController.minimizedWidth);
            }
        },

        SearchClicked: function () {
            if (!MenuController.IsMenuOpen()) {
                MenuController.HamburgerClicked(function () {
                    if (!MenuController.IsSearchOpen()) {
                        MenuController.OpenCloseSearchBar();
                    }
                });
            }
            else {
                MenuController.OpenCloseSearchBar();
            }
        },

        OpenCloseSearchBar: function () {
            var searchDiv = $("#DIV_Search");
            var cssClass = "InvisibleColumn";
            var cssClassDummy = "MySearchInvisibleColumnNotToUseAnywhereElse";
            var duration = 300;

            if (!MenuController.IsSearchOpen()) {
                searchDiv.slideDown(duration, function () {
                    searchDiv.removeClass(cssClass);
                    searchDiv.removeClass(cssClassDummy);
                });
            }
            else {
                searchDiv.slideUp(duration, function () {
                    searchDiv.addClass(cssClassDummy);
                });
            }
        },

        IsSearchOpen: function () {
            var searchDiv = $("#DIV_Search");
            var cssClass = "InvisibleColumn";
            var cssClassDummy = "MySearchInvisibleColumnNotToUseAnywhereElse";
            return !(searchDiv.hasClass(cssClass) || searchDiv.hasClass(cssClassDummy));
        },

        IsMenuOpen: function () {
            var isOpen = getSessionStorageItem('isMenuOpen');
            if (!isOpen || isOpen == 'true') {
                return true
            }
            return false;
        },

        SetVerticalMenu: function () {
            $('#TD_MenuArea').addClass('menu-vertical');
            //$('#goToHome').children().andSelf().addClass('menu-vertical');
            //$('#menuLabel').addClass('menu-vertical');
            //$('#lineGlowDiv').addClass('menu-vertical');
        },

        SetHorizontalMenu: function () {
            $('#TD_MenuArea').removeClass('menu-vertical');
            //$('#goToHome').children().andSelf().removeClass('menu-vertical');
            //$('#menuLabel').removeClass('menu-vertical');
            //$('#lineGlowDiv').removeClass('menu-vertical');
        },

        HamburgerClicked: function (callback) {
            //var url = window.MoToolsRootUrl + "/WebServices/Menu.asmx/MenuCollapsed";

            if (MenuController.IsMenuOpen()) {
                MenuController.closeMenu(callback);
            }
            else {
                MenuController.openMenu(callback);
            }
        },

        //SwapElements: function (callback) {
        //    var changeIconsTimer = 250;

        //    if ($('#IMG_Hamburger_Menu').length && $('#IMG_Search_Menu').length) {  // it exists

        //        $("#IMG_Hamburger_Menu").swap({
        //            target: "IMG_Search_Menu", // Mandatory. The ID of the element we want to swap with  
        //            opacity: "0.5", // Optional. If set will give the swapping elements a translucent effect while in motion  
        //            speed: changeIconsTimer, // Optional. The time taken in milliseconds for the animation to occur  
        //            callback: function () { // Optional. Callback function once the swap is complete
        //                callback && callback();
        //            }
        //        });
        //    }
        //},

        //CallWSMenuCollapsed: function (isCollapsed, url) {
        //    $.ajax({
        //        type: "POST",
        //        url: url,
        //        data: "{'isCollapsed':'" + isCollapsed + "'}",
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (msg) {
        //        },
        //        error: function (xhr, ajaxOptions, thrownError) {
        //        }
        //    });
        //},

        MinHeight100Percent: function () {
            var tr = $("#tablePageLayout > tbody > tr:nth-child(2)").height();
            var td = $("#tablePageLayout > tbody > tr:nth-child(2) > td").height();

            if (td > tr || td < tr) {
                //basicamente entra aqui dentro apenas no IE8!!!!!!!!!!!!!!!!!
                $("#tablePageLayout > tbody > tr:nth-child(2) > td").height(tr);
            }

            $(window).resize(function () {
                $(window).unbind("resize");
                MenuController.MinHeight100Percent();
                MenuController.AfterMenuClickedEvents();
            });
        },

        AfterMenuClickedEvents: function () {
            $('[data-onResize]').each(function (i, elem) {
                eval($(this).attr("data-onResize"));
            });

            //$("#mainPanel_ManageCase").trigger("resize");

            //$("#mainPanel_View").trigger("resize");

            //$("#mainPanel_SLA_Management").trigger("resize");
        },

        setMenuStatusCookie: function (state) {
            var data = { isMenuOpen: state }
            ajaxCall(MenuController.menuControllerUrl, 'POST', data);
            setSessionStorageItem('isMenuOpen', state);
        },

        closeMenu: function (callback) {
            //$("#TD_MenuArea").animate({
            //    width: MenuController.minimizedWidth
            //}, 500, function completed() {


            $("#menuInitialContent , #TD_MenuArea").animate({
                width: MenuController.minimizedWidth
            }, 500, function completed() {
                $("#menuInitialContent").addClass('displayNone');
                callback && callback();
                MenuController.AfterMenuClickedEvents();
            
                //$("#menuInitialContent").hide();
                callback && callback();
                MenuController.AfterMenuClickedEvents();

                MenuController.SetVerticalMenu();

                //MenuController.SwapElements(function () {
                //    $("#IMG_Search_Menu").removeAttr("style");
                //    $("#IMG_Hamburger_Menu").removeAttr("style");
                //    $("#IMG_Search_Menu").before($("#IMG_Hamburger_Menu"));
                //});
            //});

                MenuController.setMenuStatusCookie(false);
            });
        },

        openMenu: function (callback) {

            //$("#menuInitialContent , #T_ctl00UltraWebTreeMain , #TD_MenuArea").animate({
            //    width: MenuController.initialWidth
            //}, 750, function completed() {

            $("#menuInitialContent").removeClass('displayNone');
            MenuController.SetHorizontalMenu();
            $("#menuInitialContent , #T_ctl00UltraWebTreeMain , #TD_MenuArea").animate({
                width: MenuController.initialWidth
            }, 750, function completed() {
                callback && callback();
                MenuController.AfterMenuClickedEvents();

                //MenuController.SwapElements(function () {
                //    $("#IMG_Search_Menu").removeAttr("style");
                //    $("#IMG_Hamburger_Menu").removeAttr("style");
                //    $("#IMG_Hamburger_Menu").before($("#IMG_Search_Menu"));
                //});
                //});
                MenuController.setMenuStatusCookie(true);
            });
            //MenuController.CallWSMenuCollapsed(false, url);
            //$("#HF_MenuIsCollapsed").val(false);
        }
    }

    $(document).ready(function () {
        MenuController.init();

    })
})();

