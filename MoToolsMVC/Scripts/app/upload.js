(function () {
    function UploadManager() {
        var _uploadContainer,
            _this = this,
            noFileMessage = "Por favor selecione um arquivo";

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
            var input = $('.attachment-file', _uploadContainer);
            input.wrap('<form>').closest('form').get(0).reset();
            input.unwrap();
        };

        this.submitForm = function () {
            if ($('.attachment-file', _uploadContainer).val()) {
                $('.attachment-form', _uploadContainer).ajaxSubmit(function (data) {
                    alertify.success(data);
                    _this.clearFileInput();
                });
            } else {
                alertify.error(_this.noFileMessage);
            }
            return false;
        }

        return {
            init: function (uploadContainer) {
                _uploadContainer = $(uploadContainer || _uploadContainer).removeClass('upload-manager');
                _uploadContainer.off('.upload-manager'); // remove namespace handlers

                $('.attachment-popup-open', _uploadContainer).on('click.upload-manager', _this.setupPopup);
                $('.close-popup', _uploadContainer).on('click.upload-manager', _this.closePopup);
                $('.attachment-form', _uploadContainer).on('submit.upload-manager', _this.submitForm);

                _uploadContainer.addClass('upload-manager');
            }
        }
    };

    $(document).ready(function () {
        $('.upload-container').each(function (i, uploadContainer) {
            UploadManager().init(uploadContainer);
        });
    });
})();