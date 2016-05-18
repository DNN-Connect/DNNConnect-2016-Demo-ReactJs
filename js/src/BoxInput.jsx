module.exports = React.createClass({

  getInitialState() {
    return {
    }
  },

  render() {
    return (
        <p>
          <input type="text" ref="txtName" value={this.props.name} onChange={this.props.textChanged.bind(null, this)} />
        </p>
    );
  }

});
