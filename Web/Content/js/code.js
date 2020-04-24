var cy;

$(function(){ // on dom ready

  cy = cytoscape({
    container: document.getElementById('cy'),
    
    style: [{"selector":"core","style":{"selection-box-color":"#AAD8FF","selection-box-border-color":"#8BB0D0","selection-box-opacity":"0.5"}},{"selector":"node","style":{"width":"mapData(score, 0, 0.006769776522008331, 20, 60)","height":"mapData(score, 0, 0.006769776522008331, 20, 60)","content":"data(name)","font-size":"12px","text-valign":"center","text-halign":"center","background-color":"#555","text-outline-color":"#555","text-outline-width":"2px","color":"#fff","overlay-padding":"6px","z-index":"10"}},{"selector":"node[?attr]","style":{"shape":"rectangle","background-color":"#aaa","text-outline-color":"#aaa","width":"16px","height":"16px","font-size":"6px","z-index":"1"}},{"selector":"node[?query]","style":{"background-clip":"none","background-fit":"contain"}},{"selector":"node:selected","style":{"border-width":"6px","border-color":"#AAD8FF","border-opacity":"0.5","background-color":"#77828C","text-outline-color":"#77828C"}},{"selector":"edge","style":{"curve-style":"haystack","haystack-radius":"0.5","opacity":"0.4","line-color":"#bbb","width":"mapData(weight, 0, 1, 1, 8)","overlay-padding":"3px"}},{"selector":"node.unhighlighted","style":{"opacity":"0.2"}},{"selector":"edge.unhighlighted","style":{"opacity":"0.05"}},{"selector":".highlighted","style":{"z-index":"999999"}},{"selector":"node.highlighted","style":{"border-width":"6px","border-color":"#AAD8FF","border-opacity":"0.5","background-color":"#394855","text-outline-color":"#394855","shadow-blur":"12px","shadow-color":"#000","shadow-opacity":"0.8","shadow-offset-x":"0px","shadow-offset-y":"4px"}},{"selector":"edge.filtered","style":{"opacity":"0"}},{"selector":"edge[group=\"coexp\"]","style":{"line-color":"#d0b7d5"}},{"selector":"edge[group=\"coloc\"]","style":{"line-color":"#a0b3dc"}},{"selector":"edge[group=\"gi\"]","style":{"line-color":"#90e190"}},{"selector":"edge[group=\"path\"]","style":{"line-color":"#9bd8de"}},{"selector":"edge[group=\"pi\"]","style":{"line-color":"#eaa2a2"}},{"selector":"edge[group=\"predict\"]","style":{"line-color":"#f6c384"}},{"selector":"edge[group=\"spd\"]","style":{"line-color":"#dad4a2"}},{"selector":"edge[group=\"spd_attr\"]","style":{"line-color":"#D0D0D0"}},{"selector":"edge[group=\"reg\"]","style":{"line-color":"#D0D0D0"}},{"selector":"edge[group=\"reg_attr\"]","style":{"line-color":"#D0D0D0"}},{"selector":"edge[group=\"user\"]","style":{"line-color":"#f0ec86"}}],
    
    elements: [{"data":{"id":"610236","idInt":610236,"name":"RICBATCH","score":0.002235382441847178,"query":false,"gene":true},"position":{"x":205.41323994659498,"y":122.2715768040765},"group":"nodes","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":"fn10273 fn9471 fn6956 fn6935 fn8147 fn6939 fn6936 fn6957 fn8786 fn6945 fn6946 fn6811 fn6279 fn6278 fn8569 fn7641 fn8568 fn6943"},{"data":{"id":"605365","idInt":605365,"name":"APP","score":0.0021779529408011977,"query":false,"gene":true},"position":{"x":335.2681018951896,"y":398.62289259289554},"group":"nodes","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":""},{"data":{"id":"599863","idInt":599863,"name":"APP1","score":0.001982524582665901,"query":false,"gene":true},"position":{"x":422.6986944382589,"y":59.422072599905285},"group":"nodes","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":"fn10273 fn9471 fn6956 fn6935 fn8147 fn6939 fn6936 fn6957 fn8786 fn6945 fn6946 fn6811 fn6279 fn6278 fn8569 fn7641 fn8568 fn6943"},{"data":{"id":"603700","idInt":603700,"name":"APP3","score":0.001946986634883574,"query":false,"gene":true},"position":{"x":524.5786092800173,"y":313.6721385565813},"group":"nodes","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":"fn6931 fn9632 fn7950 fn9188 fn6956 fn7338 fn6629 fn6947 fn8612 fn6246 fn7453 fn7451 fn7456 fn7454 fn7469 fn7467 fn10022 fn7495 fn7500 fn7463 fn7464 fn9361"},{"data":{"id":"605846","idInt":605846,"name":"APP2","score":0.0018726190118726893,"query":false,"gene":true},"position":{"x":192.72587571240607,"y":30.601237157877808},"group":"nodes","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":"fn10273 fn6931 fn9632 fn7950 fn9188 fn9471 fn10569 fn6956 fn6935 fn8147 fn6939 fn7338 fn6936 fn6957 fn8786 fn7453 fn7451 fn6945 fn6946 fn7456 fn7454 fn7469 fn7467 fn6811 fn7463 fn7464 fn6279 fn6278 fn8569 fn7641 fn8568 fn6943"},{"data":{"id":"600535","idInt":600535,"name":"APP_XX","score":0.0018134484466597045,"query":false,"gene":true},"position":{"x":497.37919617137817,"y":693.0523864227225},"group":"nodes","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":"fn8023 fn7928"},{"data":{"id":"599724","idInt":599724,"name":"APP_X","score":0.001740600741472309,"query":false,"gene":true},"position":{"x":381.8836285591501,"y":194.7788667091606},"group":"nodes","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":"fn10273 fn9471 fn6956 fn6935 fn8147 fn6939 fn6936 fn6957 fn8786 fn6945 fn6946 fn6811 fn6279 fn6278 fn8569 fn7641 fn8568 fn6943"},
	//relazioni
	{"data":{"source":"599724","target":"610236","weight":0.011675352,"group":"coexp","networkId":1103,"networkGroupId":18,"intn":true,"rIntnId":77,"id":"e71"},"position":{},"group":"edges","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":""},
	{"data":{"source":"610236","target":"600535","weight":0.0070685484,"group":"coexp","networkId":1205,"networkGroupId":18,"intn":true,"rIntnId":46,"id":"e44"},"position":{},"group":"edges","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":""},
	{"data":{"source":"610236","target":"605365","weight":0.009479035,"group":"coexp","networkId":1205,"networkGroupId":18,"intn":true,"rIntnId":48,"id":"e46"},"position":{},"group":"edges","removed":false,"selected":false,"selectable":true,"locked":false,"grabbed":false,"grabbable":true,"classes":""}
	]
  });

  var params = {
    name: 'cola',
    nodeSpacing: 5,
    edgeLengthVal: 45,
    animate: true,
    randomize: false,
    maxSimulationTime: 1500
  };
  var layout = makeLayout();
  var running = false;

  cy.on('layoutstart', function(){
    running = true;
  }).on('layoutstop', function(){
    running = false;
  });
  
  layout.run();

  var $config = $('#config');
  var $btnParam = $('<div class="param"></div>');
  $config.append( $btnParam );

  var sliders = [
    {
      label: 'Edge length',
      param: 'edgeLengthVal',
      min: 1,
      max: 200
    },

    {
      label: 'Node spacing',
      param: 'nodeSpacing',
      min: 1,
      max: 50
    }
  ];

  var buttons = [
    {
      label: '<i class="fa fa-random"></i>',
      layoutOpts: {
        randomize: true,
        flow: null
      }
    },

    {
      label: '<i class="fa fa-long-arrow-down"></i>',
      layoutOpts: {
        flow: { axis: 'y', minSeparation: 30 }
      }
    }
  ];

  sliders.forEach( makeSlider );

  buttons.forEach( makeButton );

  function makeLayout( opts ){
    params.randomize = false;
    params.edgeLength = function(e){ return params.edgeLengthVal / e.data('weight'); };

    for( var i in opts ){
      params[i] = opts[i];
    }

    return cy.makeLayout( params );
  }

  function makeSlider( opts ){
    var $input = $('<input></input>');
    var $param = $('<div class="param"></div>');

    $param.append('<span class="label label-default">'+ opts.label +'</span>');
    $param.append( $input );

    $config.append( $param );

    var p = $input.slider({
      min: opts.min,
      max: opts.max,
      value: params[ opts.param ]
    }).on('slide', _.throttle( function(){
      params[ opts.param ] = p.getValue();

      layout.stop();
      layout = makeLayout();
      layout.run();
    }, 16 ) ).data('slider');
  }

  function makeButton( opts ){
    var $button = $('<button class="btn btn-default">'+ opts.label +'</button>');
    
    $btnParam.append( $button );

    $button.on('click', function(){
      layout.stop();

      if( opts.fn ){ opts.fn(); }

      layout = makeLayout( opts.layoutOpts );
      layout.run();
    });
  }

  cy.nodes().forEach(function(n){
    var g = n.data('name');

    n.qtip({
      content: [
        {
          name: 'GeneCard',
          url: 'http://www.genecards.org/cgi-bin/carddisp.pl?gene=' + g
        },
        {
          name: 'UniProt search',
          url: 'http://www.uniprot.org/uniprot/?query='+ g +'&fil=organism%3A%22Homo+sapiens+%28Human%29+%5B9606%5D%22&sort=score'
        },
        {
          name: 'GeneMANIA',
          url: 'http://genemania.org/search/human/' + g
        }
      ].map(function( link ){
        return '<a target="_blank" href="' + link.url + '">' + link.name + '</a>';
      }).join('<br />\n'),
      position: {
        my: 'top center',
        at: 'bottom center'
      },
      style: {
        classes: 'qtip-bootstrap',
        tip: {
          width: 16,
          height: 8
        }
      }
    });
  });

  $('#config-toggle').on('click', function(){
    $('body').toggleClass('config-closed');

    cy.resize();
  });

}); // on dom ready

$(function() {
  FastClick.attach( document.body );
});
