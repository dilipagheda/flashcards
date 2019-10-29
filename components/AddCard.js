import React, { Component } from 'react';
import { StyleSheet, View, Text, TouchableOpacity, TextInput, Button } from 'react-native';
import { purple, white, red } from '../utils/colors';
import AppButton from './AppButton';
import ErrorMsg from './ErrorMsg';
import { connect } from 'react-redux';
import { addCard } from '../actions';

class AddCard extends Component {
	state = {
		question: 'what is your name?',
		answer: 'Dilip the DON',
		errorMsg1: '',
		errorMsg2: ''
	};

	onAddCard = () => {
		const card = {
			id: this.props.navigation.state.params.id,
			question: this.state.question,
			answer: this.state.answer
		};
		this.props.dispatch(addCard(card));
		this.props.navigation.goBack(null);
	};
	render() {
		return (
			<View style={styles.container}>
				<TextInput
					placeholder="Enter Question"
					style={styles.item}
					onChangeText={(text) => this.setState({ question: text })}
					value={this.state.question}
				/>
				<ErrorMsg value={this.state.errorMsg1} />
				<TextInput
					placeholder="Enter Answer"
					style={styles.item}
					onChangeText={(text) => this.setState({ answer: text })}
					value={this.state.answer}
				/>
				<ErrorMsg value={this.state.errorMsg2} />

				<AppButton title="Add Card" onPress={this.onAddCard} />
			</View>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		borderWidth: 1,
		justifyContent: 'flex-start'
	},
	item: {
		height: 40,
		borderColor: 'gray',
		borderWidth: 1,
		margin: 10,
		padding: 5,
		fontSize: 20
	}
});

export default connect()(AddCard);
