//var CommentBox = React.createClass({
//  render: function() {
//    return (
//      <div className="commentBox">
//        Hello, world! I am a CommentBox.
//      </div>
//    );
//  }
//});
//ReactDOM.render(
//  <CommentBox />,
//  document.getElementById('content')
//);

(function () {
	var menu = {
	    init: function () {

	        var $menu = $("#menu");

	        $.getJSON(
                $menu.attr('data-src'),
                function (data) {
                    $menu.tree({
                        data: data
                    });
                }
            );
            
	        //console.log($("#menu").attr('data-src'));
			//$("#menu").tree({
			//	collapsed: true,
			//	unique: true,
			//	persist: "location",
			//	dataUrl: $("#menu").attr('data-src')
			//});
		}
	}

	menu.init();
})();

