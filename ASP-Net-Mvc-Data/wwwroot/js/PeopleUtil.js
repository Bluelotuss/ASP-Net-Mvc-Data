

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

    $.post(createForm.action,        //See previous console.log, $.post(URL,data,callback);
        {
            Name: createForm["Name"].value,     //variant of getting the form value
            PhoneNumber: createForm.PhoneNumber.value,
            City: createForm.City.value
        },
        function (data) {
            $("#personsListDiv").append(data);
            $("#createPersonDiv").html(createBtn) //document.getElementById("createPersonDiv").innerHTML = createBtn;

        }).fail(function (badForm) {
            //console.log("badForm: ", badForm);
            $("#createPersonDiv").html(badForm.responseText);
        });
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
    console.log(thePath);

    //console.log(lastItem);

    $.get(thePath, function () {
        divToReplace.remove();
    })

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

function PostEditPersonForm(event, editedForm) {
    event.preventDefault();
    
    const thePath = editedForm.action;
    const lastItem = thePath.substring(thePath.lastIndexOf('/') + 1);

    $.post(editedForm.action,
        {
            Name: editedForm.Name.value,
            PhoneNumber: editedForm.PhoneNumber.value,
            City: editedForm.City.value
        },
        function (data) {
            $("#personid" + lastItem).replaceWith(data);
        }).fail(function (badForm) {
            console.log(badForm);
            $("#personid" + lastItem).html(badForm.responseText);
        });
};



