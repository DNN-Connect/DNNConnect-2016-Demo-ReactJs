var RideRow = require('./RideRow.jsx');

module.exports = React.createClass({

  getInitialState() {
    var list = this.props.rides;
    list.sort(function(a,b) {return (a.DisplayName > b.DisplayName) ? 1 : ((b.DisplayName > a.DisplayName) ? -1 : 0);} );
    return {
      rides: list
    }
  },

  render() {
    var rideRows = this.state.rides.map((item) => {
      return <RideRow ride={item} key={item.RideId} />
    });
    var addPanel = this.props.security.IsTraveller ? (
 <div className="row">
  <div className="col-sm-12">
   <a href="#" className="btn btn-primary" onClick={this.addClick}>Add</a>
  </div>
 </div>
      ) : null;
    return (
<div class="container">
 <div className="row">
  <div className="col-sm-12">
   <table className="table table-responsive table-striped">
    <thead>
     <tr>
      <th>Name</th>
      <th>Location</th>
      <th>{this.props.resources.NrPlaces}</th>
     </tr>
    </thead>
    <tbody>
      {rideRows}
    </tbody>
   </table>
  </div>
 </div>
 {addPanel}

<div className="modal fade" id="editRide" tabindex="-1" role="dialog" aria-labelledby="editRideLabel">
 <div className="modal-dialog" role="document">
  <div className="modal-content">
   <div className="modal-header">
    <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
    <h4 className="modal-title" id="editRideLabel">Ride</h4>
   </div>
   <div className="modal-body">
    <div className="checkbox">
      <label>
        <input type="checkbox" ref="chkIncoming" /> Incoming
      </label>
    </div>
    <div className="form-group">
     <label for="txtLocation">Location</label>
     <input type="text" className="form-control" ref="txtLocation" placeholder="Location" />
    </div>
    <div className="form-group">
     <label for="txtPlaces">Nr Places</label>
     <input type="text" className="form-control" ref="txtPlaces" placeholder="Nr Places" />
    </div>
    <div className="form-group">
     <label for="txtNotes">Notes</label>
     <textarea className="form-control" ref="txtNotes" placeholder="Notes" rows="5" />
    </div>
   </div>
   <div className="modal-footer">
    <button type="button" className="btn btn-default" data-dismiss="modal">Cancel</button>
    <button type="button" className="btn btn-primary" onClick={this.updateRide}>Save</button>
   </div>
  </div>
 </div>
</div>
</div>
    );
  },

  addClick(e) {
    e.preventDefault();
    $('#editRide').modal('show');
  },

  updateRide(e) {
    e.preventDefault();
    this.props.service.addRide({
      Incoming: this.refs.chkIncoming.checked,
      Location: this.refs.txtLocation.value,
      Places: this.refs.txtPlaces.value,
      Notes: this.refs.txtNotes.value
    }, (data) => {
      var newList = this.state.rides;
      newList.push(data);
      newList.sort(function(a,b) {return (a.DisplayName > b.DisplayName) ? 1 : ((b.DisplayName > a.DisplayName) ? -1 : 0);} );
      this.setState({
        rides: newList
      });
    });
    $('#editRide').modal('hide');
  }

});
