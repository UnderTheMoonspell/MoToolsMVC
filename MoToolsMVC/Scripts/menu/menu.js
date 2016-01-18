(function () {
	var menu = {
	    init: function () {

	        var $menu = $("#menu");

	        $.getJSON(
                $menu.attr('data-src'),
                function (data) {
                    $menu.tree({
                        data: data.nodes,
                        autoOpen: false,
                        dragAndDrop: false,
                        onCreateLi : createLiFunction
                    });
                    var tree = $menu.tree('getTree');
                    tree.iterate(function (node, level) {
                        if (node.hasChildren()) {
                            $menu.tree("closeNode", node, true);
                        }
                        return true;
                    });
                }
            );
  
	        $('#menu').on('click', 'span', function () {
	            var href = $(this).attr('href');
	            if (href) {
	                window.location = href;
	            } else {
	                var nodeId = $(this).attr('node-id');
	                var node = $('#menu').tree('getNodeById', nodeId);
	                $('#menu').tree('toggle', node);
	            }
	        });

	        function createLiFunction(node, $li)
	        {
	            $li.find('.jqtree-title').attr('href', node.targetLink).attr('node-id', node.id);
	        }
		}
	}

	menu.init();
})();

