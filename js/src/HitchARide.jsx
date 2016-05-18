var MyComponent = require('./MyComponent.jsx');

(function($, window, document, undefined) {

  $(document).ready(function() {
      $('.connectHitchARide').each(function(i, el) {
        ReactDOM.render(<MyComponent name={$(el).data('name')} />, el);
      });
  });

})(jQuery, window, document);
