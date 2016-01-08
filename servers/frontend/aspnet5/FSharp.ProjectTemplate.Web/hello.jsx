var HelloBox = React.createClass({
  getInitialState: function() {
    return {firstName: 'first name', lastName: 'last name', hello: 'Press the button'};
  },  
  handleChangedFirstName: function(event) {
    this.setState({firstName: event.target.value});     
  },  
  handleChangedLastName: function(event) {
    this.setState({lastName: event.target.value});
  },
  handleSubmit: function(event) {
    console.log( this.state.firstName + ' ' + this.state.lastName );
    
    function createCORSRequest(method, url) {
      var xhr = new XMLHttpRequest();
      if ("withCredentials" in xhr) {
    
        // Check if the XMLHttpRequest object has a "withCredentials" property.
        // "withCredentials" only exists on XMLHTTPRequest2 objects.
        xhr.open(method, url, true);
    
      } else if (typeof XDomainRequest != "undefined") {
    
        // Otherwise, check if XDomainRequest.
        // XDomainRequest only exists in IE, and is IE's way of making CORS requests.
        xhr = new XDomainRequest();
        xhr.open(method, url);
    
      } else {
    
        // Otherwise, CORS is not supported by the browser.
        xhr = null;
    
      }
      return xhr;
    }    
     
    var xhr = createCORSRequest('POST', 'http://localhost:8083/api/FSharp.ProjectTemplate.Suave.Program+GreeterSQL/http_test/Greet');

    xhr.setRequestHeader('Content-Type', 'orleankka/vnd.actor+json');
    xhr.onload = function() {
        console.log(xhr.status);
        if (xhr.status === 200) {
            var hello =  xhr.responseText;
            console.log(hello);
            this.setState({hello: hello});     
        }
        else {
            alert('Request failed.  Returned status of ' + xhr.status);
        }
    }.bind(this);
    xhr.send('{ "FirstName" : "' + this.state.firstName + '", "LastName" : "' + this.state.lastName + '"  }');
  },  
  componentDidUpdate: function(prevProps, prevState) {
    console.log( prevState.firstName + ' ' + prevState.lastName );    
  },
  render: function() {
    return (
      <div className="helloBox">
        Ask when we saw each other for the last time.<br/>
        First name:<input type="text" value={this.state.firstName} onChange={this.handleChangedFirstName} /><br/>     
        Last name:<input type="text" value={this.state.lastName} onChange={this.handleChangedLastName} /><br/>  
        <button type="button" className="btn btn-primary btn-block" onClick={this.handleSubmit}>Submit</button><br/>
        <span><b>{this.state.hello}</b></span><br/>
      </div>
    );
  }
});
ReactDOM.render(
  <HelloBox />,
  document.getElementById('container')
);
