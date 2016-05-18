var RideTable = require('./RideTable.jsx');

(function($, window, document, undefined) {

  $(document).ready(function() {
      $('.connectHitchARide').each(function(i, el) {
        ReactDOM.render(<RideTable rides={$(el).data('rides')} />, el);
      });
  });

})(jQuery, window, document);
