var CampaignManager = /** @class */ (function () {
    //create
    function CampaignManager() {
        this.SearchButton = $('.search');
        this.CreateButton = $('.create');
        this.popUpModalLable = $('#popUpModalLable');
        this.InitialiseEvents();
    }
    CampaignManager.prototype.InitialiseEvents = function () {
        this.SearchButton.click(this.FilterButtonClicked);
        this.CreateButton.click(this.AddCampaign);
    };
    CampaignManager.prototype.AddCampaign = function () {
        $.ajax(URLS.Campaign.CreateCampaignPopUp, {
            //data: {
            //    id: 'some-unique-id'
            //},
            beforeSend: function () {
                $('#loader').show();
            },
            complete: function () {
                $('#loader').hide();
            }
        })
            .then(function success(data) {
            $('.layoutmodal').html("");
            $('#popUpModalLable').html("Add Campaign");
            $('.layoutmodal').html(data);
        }, function fail(data, status) {
            alert('Request failed.  Returned status of ' + status);
        });
    };
    CampaignManager.prototype.FilterButtonClicked = function () {
        $.ajax(URLS.Campaign.FilterPopUp, {
            //data: {
            //    id: 'some-unique-id'
            //},
            beforeSend: function () {
                $('#loader').show();
            },
            complete: function () {
                $('#loader').hide();
            }
        })
            .then(function success(data) {
            $('.layoutmodal').html("");
            $('#popUpModalLable').html("View Data");
            $('.layoutmodal').html(data);
        }, function fail(data, status) {
            alert('Request failed.  Returned status of ' + status);
        });
    };
    return CampaignManager;
}());
//# sourceMappingURL=Campaign.js.map