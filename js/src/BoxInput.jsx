module.exports = React.createClass({

  getInitialState() {
    return {
    }
  },

  render() {
    return (
        <p>
          <input type="text" ref="txtName" value={this.props.name} onChange={this.change} />
        </p>
    );
  },

  change() {
    this.props.textChanged(this.refs.txtName.value);
  }

});
