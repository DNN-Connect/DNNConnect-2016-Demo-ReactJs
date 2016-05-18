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
