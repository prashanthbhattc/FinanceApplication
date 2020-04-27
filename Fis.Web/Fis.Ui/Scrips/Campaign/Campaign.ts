    
    class CampaignManager {

        SearchButton: JQuery<HTMLElement>; 
        popUpModalLable: JQuery<HTMLElement>;
        CreateButton: JQuery<HTMLElement>;
            //create
        constructor() {
            this.SearchButton = $('.search');
            this.CreateButton = $('.create');
            this.popUpModalLable = $('#popUpModalLable');
            this.InitialiseEvents();
        }

        InitialiseEvents() {
            this.SearchButton.click(this.FilterButtonClicked);
            this.CreateButton.click(this.AddCampaign);
        }
        AddCampaign() {
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
                .then(
                    function success(data: HTMLElement) {

                        $('.layoutmodal').html("");
                        $('#popUpModalLable').html("Add Campaign");
                        $('.layoutmodal').html(data);
                    },

                    function fail(data, status) {
                        alert('Request failed.  Returned status of ' + status);
                    }
                );
        }

        FilterButtonClicked() {
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
                .then(
                    function success(data: HTMLElement) {
                        
                        $('.layoutmodal').html("");
                        $('#popUpModalLable').html("View Data");
                        $('.layoutmodal').html(data);
                    },

                    function fail(data, status) {
                        alert('Request failed.  Returned status of ' + status);
                    }
                );
        }
    }



