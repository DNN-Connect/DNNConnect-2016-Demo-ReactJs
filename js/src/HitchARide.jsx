var RideTable = require('./RideTable.jsx');

(function($, window, document, undefined) {

  $(document).ready(function() {
      $('.connectHitchARide').each(function(i, el) {
        ReactDOM.render(<RideTable rides={$(el).data('rides')}
                                   service={new window.ConnectHitchARideService($, $(el).data('moduleid'))}
                                   security={$(el).data('security')} />, el);
      });
  });

})(jQuery, window, document);
