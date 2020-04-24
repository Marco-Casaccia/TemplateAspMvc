CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
    config.toolbarGroups = [
		{ name: 'document', groups: [ 'mode', 'document', 'doctools' ] },
		{ name: 'clipboard', groups: [ 'clipboard', 'undo' ] },
		{ name: 'editing', groups: [ 'find', 'selection', 'spellchecker', 'editing' ] },
		{ name: 'forms', groups: [ 'forms' ] },
		{ name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
		{ name: 'links', groups: [ 'links' ] },
		'/',
		{ name: 'paragraph', groups: [ 'list', 'indent', 'blocks', 'align', 'bidi', 'paragraph' ] },
		{ name: 'insert', groups: [ 'insert' ] },
		{ name: 'colors', groups: [ 'colors' ] },
		'/',
		{ name: 'styles', groups: [ 'styles' ] },
		{ name: 'tools', groups: [ 'tools' ] },
		{ name: 'others', groups: [ 'others' ] }
    ];

    config.removeButtons = 'about,Form,Checkbox,Radio,TextField,Textarea,Select,ImageButton,Button,HiddenField,Flash,Smiley,SpecialChar,Iframe,Templates,NewPage,Save,Source,Replace,Find';
};
CKEDITOR.on('dialogDefinition', function (ev) {
    // Take the dialog name and its definition from the event data.
    var dialogName = ev.data.name;
    var dialogDefinition = ev.data.definition;

    // Check if the definition is from the dialog window you are interested in (the "Link" dialog window).
    if (dialogName == 'link') {
        // Get a reference to the "Link Info" tab.
        var infoTab = dialogDefinition.getContents('info');

        // Set the default value for the URL field.
        var urlField = infoTab.get('url');
        urlField['default'] = 'www.example.com';
    }
});
