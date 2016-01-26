(function () {
    function UploadManager() {
        var _uploadContainer,
            _this = this;

        this.setupPopup = function () {
            var combo = $('.attachment-type', _uploadContainer);
            if (!$('option', combo).length) {
                $.get('/Team/GetUploadAttachmentTypes', {}, function (data) {
                    data.forEach(function (option) {
                        combo.append($('<option/>', { text: option.Text, value: option.ID }));
                    });
                    showPopup();
                });
            } else {
                showPopup();
            };
        };

        this.showPopup = function (e) {
            e && e.preventDefault();
            $('.upload-popup', _uploadContainer).show();
            clearFileInput();
        };

        this.closePopup = function (e) {
            e && e.preventDefault();
            $('.upload-popup', _uploadContainer).hide();
            clearFileInput();
        };

        this.clearFileInput = function () {
            $('.attachment-file', _uploadContainer).wrap('<form>').closest('form').get(0).reset();
            $('.attachment-file', _uploadContainer).unwrap();
        };

        return {
            init: function (uploadContainer) {
                _uploadContainer = uploadContainer;
                $('.attachment-popup-open', uploadContainer).click(_this.setupPopup);
                $('.close-popup', uploadContainer).click(_this.closePopup);
                $('.attachment-form', uploadContainer).ajaxForm(function (data) {
                    alertify.success(data);
                    closePopup();
                });
            }
        }
    };

    $(document).ready(function () {
        $('.upload-container').each(function (i, uploadContainer) {
            UploadManager().init(uploadContainer);
        });
    });
})();