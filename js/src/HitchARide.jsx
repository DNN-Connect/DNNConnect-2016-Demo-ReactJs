var MyComponent = React.createClass({

  getInitialState() {
    return {
      name: 'DNN Connect'
    }
  },

  render() {
    return (
      <div>
        <h1>Hello {this.state.name}!</h1>
        <p><input type="text" ref="txtName" value={this.state.name} onChange={this.textChanged} /></p>
      </div>
    );
  },

  textChanged() {
    this.setState({
      name: this.refs.txtName.value
    });
  }

});

(function($, window, document, undefined) {

  $(document).ready(function() {
      $('.connectHitchARide').each(function(i, el) {
        ReactDOM.render(<MyComponent />, el);
      });
  });

})(jQuery, window, document);
