module.exports = React.createClass({

  render() {
    return (
      <tr>
        <td>{this.props.ride.DisplayName}</td>
        <td>{this.props.ride.Location}</td>
        <td>{this.props.ride.PlacesAvailable}</td>
      </tr>
    );
  }

});
