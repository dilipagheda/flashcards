import React, { Component } from 'react';
import { StyleSheet, View, Text, Button } from 'react-native';
import { purple, white } from '../utils/colors';
import DeckItem from './DeckItem';
import { TouchableOpacity } from 'react-native-gesture-handler';
import AppButton from './AppButton';

class DeckDetail extends Component {
	render() {
		return (
			<View style={styles.container}>
				<View>
					<Text style={styles.itemHeader}>Deck 1</Text>
					<Text style={styles.itemFooter}>0 cards</Text>
				</View>
				<View style={styles.a}>
					<View style={styles.b}>
						<AppButton title="Add Card" />
						<AppButton title="Start Quiz" />
					</View>
				</View>
				<Button title="Delete Deck" />
			</View>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		backgroundColor: white,
		justifyContent: 'space-around'
	},
	itemHeader: {
		textAlign: 'center',
		fontSize: 40
	},
	itemFooter: {
		textAlign: 'center',
		fontSize: 30
	},
	a: {
		marginBottom: 50
	},
	b: {}
});
export default DeckDetail;
