var BoxInput = require('./BoxInput.jsx');

module.exports = React.createClass({

  getInitialState() {
    return {
      name: this.props.name
    }
  },

  render() {
    return (
      <div>
        <h1>Hello {this.state.name}!</h1>
        <BoxInput name={this.state.name} textChanged={this.textChanged} />
      </div>
    );
  },

  textChanged(boxInp) {
    this.setState({
      name: boxInp.refs.txtName.value
    });
  }

});
