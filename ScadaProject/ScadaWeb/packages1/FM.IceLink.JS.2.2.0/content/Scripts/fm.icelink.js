
/*
 * Vendor: Frozen Mountain Software
 * Title: IceLink for JavaScript
 * Version: 2.2.0
 * Copyright Frozen Mountain Software 2011+
 */

if (typeof global !== 'undefined' && !global.window) { global.window = global; global.document = { cookie: '' }; }

if (!window.fm) { window.fm = {}; }

if (!window.fm.icelink) { window.fm.icelink = {}; }

var __bind =  function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

var __hasProp =  {}.hasOwnProperty;

var __extends =  function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

fm.icelink.candidate = (function() {

  function candidate() {
    this.toJson = __bind(this.toJson, this);

    this.getSdpCandidateAttribute = __bind(this.getSdpCandidateAttribute, this);

    this.setSdpCandidateAttribute = __bind(this.setSdpCandidateAttribute, this);

    this.getSdpMediaIndex = __bind(this.getSdpMediaIndex, this);

    this.setSdpMediaIndex = __bind(this.setSdpMediaIndex, this);

  }

  candidate.prototype._sdpMediaIndex = 0;

  candidate.prototype._sdpCandidateAttribute = null;

  candidate.prototype.setSdpMediaIndex = function(sdpMediaIndex) {
    return this._sdpMediaIndex = sdpMediaIndex;
  };

  candidate.prototype.getSdpMediaIndex = function() {
    return this._sdpMediaIndex;
  };

  candidate.prototype.setSdpCandidateAttribute = function(sdpCandidateAttribute) {
    return this._sdpCandidateAttribute = sdpCandidateAttribute;
  };

  candidate.prototype.getSdpCandidateAttribute = function() {
    return this._sdpCandidateAttribute;
  };

  candidate.prototype.toJson = function() {
    return fm.icelink.candidate.toJson(this);
  };

  candidate.toJson = function(c) {
    var co;
    co = {
      sdpMediaIndex: c.getSdpMediaIndex(),
      sdpCandidateAttribute: c.getSdpCandidateAttribute()
    };
    return fm.json.serialize(co);
  };

  candidate.fromJson = function(candidateJson) {
    var c, co;
    co = fm.json.deserialize(candidateJson);
    c = new fm.icelink.candidate();
    c.setSdpMediaIndex(co.sdpMediaIndex);
    c.setSdpCandidateAttribute(co.sdpCandidateAttribute);
    return c;
  };

  return candidate;

}).call(this);


var __bind = function(fn, me){ return function(){ return fn.apply(me, arguments); }; };

fm.icelink.offerAnswer = (function() {

  function offerAnswer() {
    this.toJson = __bind(this.toJson, this);

    this.getIsOffer = __bind(this.getIsOffer, this);

    this.setIsOffer = __bind(this.setIsOffer, this);

    this.getSdpMessage = __bind(this.getSdpMessage, this);

    this.setSdpMessage = __bind(this.setSdpMessage, this);

  }

  offerAnswer.prototype._sdpMessage = null;

  offerAnswer.prototype._isOffer = false;

  offerAnswer.prototype.setSdpMessage = function(sdpMessage) {
    return this._sdpMessage = sdpMessage;
  };

  offerAnswer.prototype.getSdpMessage = function() {
    return this._sdpMessage;
  };

  offerAnswer.prototype.setIsOffer = function(isOffer) {
    return this._isOffer = isOffer;
  };

  offerAnswer.prototype.getIsOffer = function() {
    return this._isOffer;
  };

  offerAnswer.prototype.toJson = function() {
    return fm.icelink.offerAnswer.toJson(this);
  };

  offerAnswer.toJson = function(oa) {
    var oao;
    oao = {
      sdpMessage: oa.getSdpMessage(),
      isOffer: oa.getIsOffer()
    };
    return fm.json.serialize(oao);
  };

  offerAnswer.fromJson = function(offerAnswerJson) {
    var oa, oao;
    oao = fm.json.deserialize(offerAnswerJson);
    oa = new fm.icelink.offerAnswer();
    oa.setSdpMessage(oao.sdpMessage);
    oa.setIsOffer(oao.isOffer);
    return oa;
  };

  return offerAnswer;

}).call(this);


/**
@class fm.icelink.peerClient
 <div>
 Base implementation of a peer client.
 </div>

@extends fm.object
*/


fm.icelink.peerClient = (function(_super) {

  __extends(peerClient, _super);

  /**
  	@ignore 
  	@description
  */


  function peerClient() {
    this.getId = __bind(this.getId, this);
    if (arguments.length === 1 && fm.util.isPlainObject(arguments[0]) && fm.util.canAttachProperties(this, arguments[0])) {
      peerClient.__super__.constructor.call(this);
      fm.util.attachProperties(this, arguments[0]);
      return;
    }
    peerClient.__super__.constructor.call(this);
  }

  /**
  	 <div>
  	 Gets the peer client ID as a string.
  	 </div><returns>The peer client ID.</returns>
  
  	@function getId
  	@return {fm.string}
  */


  peerClient.prototype.getId = function() {};

  return peerClient;

})(fm.object);


/**
@class fm.icelink.connectionHubProvider
 <div>
 Abstract definition of a connection-hub provider for client
 registration and out-of-band message delivery.
 </div>

@extends fm.object
*/


fm.icelink.connectionHubProvider = (function(_super) {

  __extends(connectionHubProvider, _super);

  /**
  	@ignore 
  	@description
  */


  connectionHubProvider.prototype._onPeerCandidate = null;

  /**
  	@ignore 
  	@description
  */


  connectionHubProvider.prototype._onPeerOfferAnswer = null;

  /**
  	@ignore 
  	@description
  */


  function connectionHubProvider() {
    this.setOnPeerOfferAnswer = __bind(this.setOnPeerOfferAnswer, this);

    this.setOnPeerCandidate = __bind(this.setOnPeerCandidate, this);

    this.sendOfferAnswer = __bind(this.sendOfferAnswer, this);

    this.sendCandidate = __bind(this.sendCandidate, this);

    this.raisePeerOfferAnswer = __bind(this.raisePeerOfferAnswer, this);

    this.raisePeerCandidate = __bind(this.raisePeerCandidate, this);

    this.getOnPeerOfferAnswer = __bind(this.getOnPeerOfferAnswer, this);

    this.getOnPeerCandidate = __bind(this.getOnPeerCandidate, this);
    if (arguments.length === 1 && fm.util.isPlainObject(arguments[0]) && fm.util.canAttachProperties(this, arguments[0])) {
      connectionHubProvider.__super__.constructor.call(this);
      fm.util.attachProperties(this, arguments[0]);
      return;
    }
    connectionHubProvider.__super__.constructor.call(this);
  }

  /**
  	 <div>
  	 Gets the callback to invoke when a candidate is raised.
  	 </div>
  
  	@function getOnPeerCandidate
  	@return {fm.doubleAction}
  */


  connectionHubProvider.prototype.getOnPeerCandidate = function() {
    return this._onPeerCandidate;
  };

  /**
  	 <div>
  	 Gets the callback to invoke when an offer or answer is raised.
  	 </div>
  
  	@function getOnPeerOfferAnswer
  	@return {fm.doubleAction}
  */


  connectionHubProvider.prototype.getOnPeerOfferAnswer = function() {
    return this._onPeerOfferAnswer;
  };

  /**
  	 <div>
  	 Raises a received candidate for processing by the hub.
  	 </div><param name="peerClient">The peer client who sent the candidate.</param><param name="candidate">The candidate.</param>
  
  	@function raisePeerCandidate
  	@param {fm.object} peerClient
  	@param {fm.icelink.candidate} candidate
  	@return {void}
  */


  connectionHubProvider.prototype.raisePeerCandidate = function() {
    var candidate, onPeerCandidate, peerClient, _var0;
    peerClient = arguments[0];
    candidate = arguments[1];
    onPeerCandidate = this.getOnPeerCandidate();
    _var0 = onPeerCandidate;
    if (_var0 !== null && typeof _var0 !== 'undefined') {
      return onPeerCandidate(peerClient, candidate);
    }
  };

  /**
  	 <div>
  	 Raises a received offer or answer for processing by the hub.
  	 </div><param name="peerClient">The peer client who sent the offer or answer.</param><param name="offerAnswer">The offer or answer.</param>
  
  	@function raisePeerOfferAnswer
  	@param {fm.object} peerClient
  	@param {fm.icelink.offerAnswer} offerAnswer
  	@return {void}
  */


  connectionHubProvider.prototype.raisePeerOfferAnswer = function() {
    var offerAnswer, onPeerOfferAnswer, peerClient, _var0;
    peerClient = arguments[0];
    offerAnswer = arguments[1];
    onPeerOfferAnswer = this.getOnPeerOfferAnswer();
    _var0 = onPeerOfferAnswer;
    if (_var0 !== null && typeof _var0 !== 'undefined') {
      return onPeerOfferAnswer(peerClient, offerAnswer);
    }
  };

  /**
  	 <div>
  	 Sends a candidate to a peer client.
  	 </div><param name="peerClient">The peer client who should receive the candidate.</param><param name="candidate">The candidate to send.</param>
  
  	@function sendCandidate
  	@param {fm.object} peerClient
  	@param {fm.icelink.candidate} candidate
  	@return {void}
  */


  connectionHubProvider.prototype.sendCandidate = function() {
    var candidate, peerClient;
    peerClient = arguments[0];
    return candidate = arguments[1];
  };

  /**
  	 <div>
  	 Sends an offer or answer to a peer client.
  	 </div><param name="peerClient">The peer client who should receive the offer or answer.</param><param name="offerAnswer">The offer or answer.</param>
  
  	@function sendOfferAnswer
  	@param {fm.object} peerClient
  	@param {fm.icelink.offerAnswer} offerAnswer
  	@return {void}
  */


  connectionHubProvider.prototype.sendOfferAnswer = function() {
    var offerAnswer, peerClient;
    peerClient = arguments[0];
    return offerAnswer = arguments[1];
  };

  /**
  	 <div>
  	 Sets the callback to invoke when a candidate is raised.
  	 </div>
  
  	@function setOnPeerCandidate
  	@param {fm.doubleAction} value
  	@return {void}
  */


  connectionHubProvider.prototype.setOnPeerCandidate = function() {
    var value;
    value = arguments[0];
    return this._onPeerCandidate = value;
  };

  /**
  	 <div>
  	 Sets the callback to invoke when an offer or answer is raised.
  	 </div>
  
  	@function setOnPeerOfferAnswer
  	@param {fm.doubleAction} value
  	@return {void}
  */


  connectionHubProvider.prototype.setOnPeerOfferAnswer = function() {
    var value;
    value = arguments[0];
    return this._onPeerOfferAnswer = value;
  };

  return connectionHubProvider;

})(fm.object);
