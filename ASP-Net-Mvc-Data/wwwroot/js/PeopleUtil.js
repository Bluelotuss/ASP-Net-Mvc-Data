
var page_item = 0;
var records_per_page = 3;
var current_page = 1;
var num_of_pages = 1;

var page_btn = document.getElementById("page_btn");
var next_page_btn = document.getElementById("next_page_btn");
var prev_page_btn = document.getElementById("prev_page_btn");
var data_num_pages = document.getElementById("data_num_pages");
var data_num_items = document.getElementById("data_num_items");

function FindByCityOrName(event, urlHelper) {
    event.preventDefault();
                                                            //console.log(event);
    const anchorElement = event.target;
    const inputValue = $('#searchInput').val();
    //console.log(urlHelper);
    //console.log(anchorElement.attributes.href.value);
    divToReplace = $("#personsListDiv");
    //console.log(inputValue.length);
    
    if (inputValue != 0) {


        $.get(anchorElement.attributes.href.value + "/" + inputValue, function (result) {

            //$('#' + anchorElement.attributes["data-target"].value).html(result);
            divToReplace.html(result)
        })
    } else {
        $.get(urlHelper + "/" + "", function (result) {
            console.log(urlHelper);
            //$('#' + anchorElement.attributes["data-target"].value).html(result);
            divToReplace.html(result);

        })
    }
};

function GetCreatePersonForm(urlToCreateForm) {
    createBtn = $("#btn-person-create");

    $.get(urlToCreateForm, function (result) {
        createBtn.replaceWith(result);
    })
};

function PostCreatePersonForm(event, createForm) {
    event.preventDefault(); //prevent from loading form on new page

                                                    //console.log("Create Form post:"), createForm); Would show the form loaded in console

                                                    //console.log("action url:", createForm.action);
                                                    //console.log("form value brand:", createForm.Brand.value);

    $.post(createForm.action,                           //See previous console.log, $.post(URL,data,callback);
        {
            Name: createForm["Name"].value,             //variant of getting the form value
            PhoneNumber: createForm.PhoneNumber.value,
            City: createForm.City.value
        },
        function (data) {
            $("#personsListDiv").append(data);
            $("#createPersonDiv").html(createBtn);               //document.getElementById("createPersonDiv").innerHTML = createBtn;

        }).fail(function (badForm) {
                                                                    //console.log("badForm: ", badForm);
            $("#createPersonDiv").html(badForm.responseText);
        });

    page_item++;
    num_of_pages = NumberOfPages();
    Pagination();

    data_num_pages.innerHTML = "<p>Number of pages: " + num_of_pages + "</p>";
    data_num_items.innerHTML = "<p>Number of items: " + page_item + "</p>";
    
};

function GetDelete(event) {
    event.preventDefault();
    //console.log(urlHelper);
    //console.log(event);
    const anchorElement = event.target;
    //console.log(anchorElement.attributes.href.value);
    const thePath = anchorElement.attributes.href.value;
    const lastItem = thePath.substring(thePath.lastIndexOf('/') + 1);


    divToReplace = $("#personid" + lastItem);

    console.log(lastItem);
    console.log(divToReplace);
    console.log("The path:", thePath);

    //console.log(lastItem);

    $.get(thePath, function () {
        divToReplace.remove();
    })

    page_item--;

};

function GetEdit(event, urlHelper) {
    event.preventDefault();

    
    const thePath = urlHelper;
    console.log(thePath);
    const lastItem = thePath.substring(thePath.lastIndexOf('/') + 1);

    divToReplace = $("#personid" + lastItem);

    $.get(thePath, function (result) {
        divToReplace.html(result)
    })
}

function PostEditPersonForm(event, editedForm, modelId) {       //Instead of using the path and lastItem
    event.preventDefault();

    //console.log(modelId);
    //const thePath = editedForm.action;
    //const lastItem = thePath.substring(thePath.lastIndexOf('/') + 1);

    $.post(editedForm.action,
        {
            Name: editedForm.Name.value,
            PhoneNumber: editedForm.PhoneNumber.value,
            City: editedForm.City.value
        },
        function (data) {
            $("#personid" + modelId).replaceWith(data);
        }).fail(function (badForm) {
            //console.log(badForm);
            $("#personid" + modelId).html(badForm.responseText);
        });
};

//--------------------------- Pagination -------------------------------------------------

function Pagination() {
        NextPageVisibillity();
        PrevPageVisibility();

    $.get("/AjaxPersons/AjaxPage/", { currentPage: current_page, numOfPages: num_of_pages, recordsPerPage: records_per_page, numOfPageItems: page_item }, function (result) {
            $("#personsListDiv").html(result)
        });
}

function NextPage(event, urlHelper) {
    event.preventDefault();

    var page_index = current_page + 2;

    next_page_btn.setAttribute("href", "/AjaxPersons/AjaxNextPage/" + page_index);

    current_page++;

        $.get("/AjaxPersons/AjaxNextPage/", { currentPage: current_page, numOfPages: num_of_pages, recordsPerPage: records_per_page }, function (result) {
            $("#personsListDiv").html(result)
        });
    
    NextPageVisibillity();
    PrevPageVisibility();
}

function PrevPage(event, urlHelper) {
    event.preventDefault();

    var page_index = current_page - 1;
    prev_page_btn.setAttribute("href", "/AjaxPersons/AjaxPrevPage/" + page_index);

    current_page--;

    $.get("/AjaxPersons/AjaxPrevPage/", { currentPage: current_page, numOfPages: num_of_pages, recordsPerPage: records_per_page }, function (result) {
            $("#personsListDiv").html(result)
    });
    
    NextPageVisibillity();
    PrevPageVisibility();
}

function NextPageVisibillity() {
    if (NumberOfPages() > current_page) {
        next_page_btn.style.visibility = "visible";
    } else {
        next_page_btn.style.visibility = "hidden";
    }
}

function PrevPageVisibility() {
    if (current_page > 1) {
        prev_page_btn.style.visibility = "visible";
    } else {
        prev_page_btn.style.visibility = "hidden";
    }
}

function NumberOfPages() {

    return Math.ceil(page_item / records_per_page);
}

