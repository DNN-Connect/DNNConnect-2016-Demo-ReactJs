var MyComponent = React.createClass({

  getInitialState() {
    return {
    }
  },

  render() {
    return (
      <h1>Hello DNN Connect!</h1>
    );
  }

});

(function($, window, document, undefined) {

  $(document).ready(function() {
      $('.connectHitchARide').each(function(i, el) {
        ReactDOM.render(<MyComponent />, el);
      });
  });

})(jQuery, window, document);
